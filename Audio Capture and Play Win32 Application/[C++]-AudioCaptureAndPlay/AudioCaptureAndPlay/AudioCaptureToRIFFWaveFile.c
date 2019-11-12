/*
	Author: James Pate Williams, Jr. (c) 2016

	Audio Capture to RIFF Wave File
*/

#include <fcntl.h>
#include <io.h>
#include <string.h>
#include <time.h>
#include <windows.h>
#include <commdlg.h>
#include <winsock.h>
#include <mmsystem.h>
#include <process.h>
#include <stdlib.h>
#include <sys\stat.h>
#include "resource.h"

#define NUMBERBUTTONS 6
#define ACBSIZE 2 * 44100 * 60 * 15
#define UW_WIDTH 1012
#define UW_HEIGHT 800
#define bzero(s, n) memset((s), 0, (n));

char copyright[256], title[256];
char data[4] = { 'd', 'a', 't', 'a' };
char fmt_[4] = { 'f', 'm', 't', ' ' };
char junk[4] = { 'J', 'U', 'N', 'K' };
char riff[4] = { 'R', 'I', 'F', 'F' };
char wave[4] = { 'W', 'A', 'V', 'E' };
int handle = -1, audioLength = 0, audioPtr = 0;
int acbSize = ACBSIZE, fileCount, page;
enum ReadCDRIFFWaveFileError {
	NoError = 0,
	RIFFCorrupt = 1,
	cbSizeFileCorrupt = 2,
	WAVECorrupt = 3,
	fmt_Corrupt = 4,
	cbSizeSubChunkCorrupt = 5,
	AudioFormatError = 6,
	NumChannelsError = 7,
	SampleRateError = 8,
	ByteRateError = 9,
	BlockAlignError = 10,
	BitsPerSampleError = 11,
	JUNKCorrupt = 12,
	cbSizeJunkCorrupt = 13,
	DATACorrupt = 14,
	AudioLengthError = 15
};
BOOL drawSelected = FALSE, playSelected = FALSE, recdSelected = FALSE;
BOOL recording = FALSE, playing = FALSE, stopped = FALSE;
BYTE audioCaptureBuffer[ACBSIZE];
BYTE waveHdrBuffer[2 * 44100];
CRITICAL_SECTION cs;
HINSTANCE hInst;
HWAVEIN waveIn;
HWAVEOUT waveOut;
HWND hWnd;
HWND hwndButton[NUMBERBUTTONS];
WAVEFORMATEX waveformat;
WAVEHDR waveHeader;

void InitializeOpenFilename(OPENFILENAME *openFilename) {
	static char szFilter[] = "WAVE Files (*.wav)\0*.wav\0\0";

	memset(openFilename, 0, sizeof(*openFilename));
	openFilename->lStructSize = sizeof(*openFilename);
	openFilename->lpstrFilter = szFilter;
	openFilename->nMaxFile = _MAX_PATH;
	openFilename->nMaxFileTitle = _MAX_FNAME + _MAX_EXT;
}

BOOL FindFileHandle(char *filename, BOOL output) {

	if (output)
		handle = open(filename, O_BINARY | O_WRONLY | O_CREAT | O_TRUNC, S_IWRITE);
	else
		handle = open(filename, O_BINARY | O_RDONLY, S_IREAD);

	if (handle == - 1) {
		MessageBox(hWnd, "can't open file", "Warning Message",
			MB_ICONEXCLAMATION | MB_OK);
		return FALSE;
	}
	return TRUE;
}

MMRESULT FindSuitableInputDevice(HWND hwndProc)
{
	return waveInOpen(&waveIn, WAVE_MAPPER, &waveformat, hwndProc, 
		hInst, CALLBACK_WINDOW);
}

MMRESULT FindSuitableOutputDevice(HWND hwndProc)
{
	return waveOutOpen(&waveOut, WAVE_MAPPER, &waveformat, hwndProc,
		hInst, CALLBACK_WINDOW);
}

BOOL EqualBuffer(BYTE *buffer1, BYTE *buffer2, int length)
{
	BOOL equal = TRUE;
	int i;

	for (i = 0; equal && i < length; i++)
		equal = buffer1[i] == buffer2[i];

	return equal;
}

void ClearWave(HWND hwnd, int buttonsY)
{
	HBRUSH wb = (HBRUSH)GetStockObject(WHITE_BRUSH);
	HDC hdc = GetDC(hwnd);
	RECT r, rect;

	GetClientRect(hwnd, &rect);

	r = rect;
	r.top = rect.top + buttonsY;
	
	FillRect(hdc, &r, wb);
	ReleaseDC(hwnd, hdc);
}

void DrawLine(HDC hdc, int x1, int y1, int x2, int y2)
{
	MoveToEx(hdc, x1, y1, NULL);
	LineTo(hdc, x2, y2);
}

void DrawWave(HWND hwnd, int buttonsY)
{
	HDC hdc = GetDC(hwnd);
	RECT rect;

	double xInter, xSlope;
	double yInter, ySlope;
	
	int i, width, height;
	int oldX, oldY;
	int dMax, dMin;
	int iMax, iMin;
	int xMax, xMin;
	int yMax, yMin;

	GetClientRect(hwnd, &rect);

	width = rect.right - rect.left;
	height = rect.bottom - rect.top - buttonsY;
	xMin = 0;
	xMax = width - 1;
	yMin = height - 1;
	yMax = buttonsY;

	dMin = +127;
	dMax = -128;
	iMin = 0;
	iMax = 256;

	for (i = 0; i < audioLength; i++)
	{
		signed char bb = audioCaptureBuffer[i];

		if (bb < dMin)
			dMin = bb;

		if (bb > dMax)
			dMax = bb;
	}

	xSlope = 1.0 / ((double)(iMax - iMin) / (xMax - xMin));
	ySlope = 1.0 / ((double)(dMax - dMin) / (yMin - yMax));
	xInter = xMin - xSlope * iMin;
	yInter = yMax - ySlope * dMin;
	
	for (i = 0; i < iMax; i++)
	{
		signed char d = audioCaptureBuffer[256 * page + i];
		int x = (int)(xSlope * i + xInter);
		int y = (int)(ySlope * d + yInter);

		if (i == 0)
		{
			oldX = x;
			oldY = y;
			continue;
		}
		
		DrawLine(hdc, oldX, oldY, x, y);
		oldX = x;
		oldY = y;
	}

	ReleaseDC(hwnd, hdc);
}

enum ReadCDRIFFFileError ReadAudioCDRIFFFile()
{
	BYTE DATA[4], FMT_[4], JUNK[4], RIFF[4], WAVE[4];
	char junkBuffer[4096];
	int cdSizeData, cbSizeFile, cbSizeJunk, cbSizeSubChunk, x;
	short audioFormat;
	short numChannels;
	int sampleRate;
	int byteRate;
	short blockAlign;
	short bitsPerSample;
	short pad;
	
	read(handle, RIFF, 4);

	if (!EqualBuffer(riff, RIFF, 4))
		return RIFFCorrupt;

	read(handle, &cbSizeFile, sizeof(cbSizeFile));

	if (cbSizeFile < 0)
		return cbSizeFileCorrupt;

	read(handle, WAVE, 4);

	if (!EqualBuffer(wave, WAVE, 4))
		return WAVECorrupt;

	read(handle, FMT_, 4);

	if (!EqualBuffer(fmt_, FMT_, 4))
		return fmt_Corrupt;

	read(handle, &cbSizeSubChunk, sizeof(cbSizeSubChunk));

	if (cbSizeSubChunk != 18)
		return cbSizeSubChunkCorrupt;

	read(handle, &audioFormat, sizeof(audioFormat));

	if (audioFormat != WAVE_FORMAT_PCM)
		return AudioFormatError;

	read(handle, &numChannels, sizeof(numChannels));

	if (numChannels != 2)
		return NumChannelsError;

	read(handle, &sampleRate, sizeof(sampleRate));

	if (sampleRate != 44100)
		return SampleRateError;

	read(handle, &byteRate, sizeof(byteRate));

	if (byteRate != 44100 * 2 * 16 / 8)
		return ByteRateError;

	read(handle, &blockAlign, sizeof(blockAlign));

	if (blockAlign != 4)
		return BlockAlignError;

	read(handle, &bitsPerSample, sizeof(bitsPerSample));

	if (bitsPerSample != 16)
		return BitsPerSampleError;

	read(handle, &pad, sizeof(pad));

	for (x = 0; x < 4096; x++)
		junkBuffer[x] = 0;

	read(handle, JUNK, 4);

	if (!EqualBuffer(junk, JUNK, 4))
		return JUNKCorrupt;

	read(handle, &cbSizeJunk, sizeof(cbSizeJunk));

	if (cbSizeJunk < 0 || cbSizeJunk > 4096)
		return cbSizeJunkCorrupt;

	read(handle, junkBuffer, cbSizeJunk);

	read(handle, DATA, 4);

	if (!EqualBuffer(data, DATA, 4))
		return DATACorrupt;

	read(handle, &audioLength, sizeof(audioLength));

	if (audioLength < 0 || audioLength > acbSize)
		return AudioLengthError;

	read(handle, audioCaptureBuffer, audioLength);
	audioPtr = 0;
	close(handle);
	return NoError;
}

void WriteAudioCDRIFFFile()
{
	char junkBuffer[4096];
	int chunkSize = 0, junkSize = 0, k, x;

	for (x = audioLength; x < audioLength + 4096; x++)
	{
		k = (x + 54) % 4096;

		if (k == 0)
		{
			junkSize = (x + 46) % 4096 - 46;
			chunkSize = audioLength + (x + 46) % 4096;
			break;
		}
	}

	write(handle, riff, 4);
	write(handle, &chunkSize, sizeof(chunkSize));
	write(handle, wave, 4);
	write(handle, fmt_, 4);

	int subChunkSize1 = 18;
	short audioFormat = 1;
	short numChannels = 2;
	int sampleRate = 44100;
	int byteRate = 44100 * 2 * 16 / 8;
	short blockAlign = 4;
	short bitsPerSample = 16;
	short pad = 0;

	write(handle, &subChunkSize1, sizeof(subChunkSize1));
	write(handle, &audioFormat, sizeof(audioFormat));
	write(handle, &numChannels, sizeof(numChannels));
	write(handle, &sampleRate, sizeof(sampleRate));
	write(handle, &byteRate, sizeof(byteRate));
	write(handle, &blockAlign, sizeof(blockAlign));
	write(handle, &bitsPerSample, sizeof(bitsPerSample));
	write(handle, &pad, sizeof(pad));

	for (x = 0; x < junkSize; x++)
		junkBuffer[x] = 0;

	write(handle, junk, 4);
	write(handle, &junkSize, sizeof(junkSize));

	write(handle, junkBuffer, junkSize);

	write(handle, data, 4);
	write(handle, &audioLength, sizeof(audioLength));
	
	write(handle, audioCaptureBuffer, audioLength);
	close(handle);
}

LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam) {
	char none[32];
	enum ReadCDRIFFWaveFileError error;
	struct {
		long style;
		char *text;
	} button[] = { { BS_PUSHBUTTON, "Draw Wave Data" },
				   { BS_PUSHBUTTON, "Start Playing"},
				   { BS_PUSHBUTTON, "Start Recording" },
				   { BS_PUSHBUTTON, "Clear Wave Drawing" },
				   { BS_PUSHBUTTON, "Wave Data Page Up"  },
				   { BS_PUSHBUTTON, "Wave Data Page Dn"  }
	};
	DWORD dWord1 = 0, dWord2 = 0;
	HDC hdc;
	PAINTSTRUCT ps;
	RECT rect;
	UINT cbWaveHeader, count = 0, i, nDevices, uMessage = 0;
	WSADATA wsaData;
	OPENFILENAME openFilename;
	MMRESULT result;
	static char filename[_MAX_FNAME + 1] = {'\0'};
	static char fileTitle[_MAX_FNAME + _MAX_EXT + 1] = {'\0'};
	static int cxClient, cyClient;
	static int buttonsY, j, chunkSize = 0, junkSize = 0, maxPages, playLength, x, y;
	static BOOL mouseOn = FALSE, rf;
	static RECT channelRect[16];

	switch (iMsg) {
		case WM_COMMAND:
			if (LOWORD(wParam) == 0)
			{
				BOOL openFile;
				MMRESULT result;

				InitializeOpenFilename(&openFilename);
				openFilename.lpstrFile = filename;
				openFilename.lpstrFileTitle = fileTitle;
				openFilename.Flags = 0;

				if (GetOpenFileName(&openFilename)) {
					openFile = FindFileHandle(filename, FALSE);

					if (openFile) {
						ReadAudioCDRIFFFile();
						page = 0;
						maxPages = audioLength / 256;
						DrawWave(hwnd, buttonsY);
					}
				}
			}
			else if (LOWORD(wParam) == 1) {
				if (playing == FALSE && playSelected == FALSE)
				{
					BOOL openFile;
					MMRESULT result;

					InitializeOpenFilename(&openFilename);
					openFilename.lpstrFile = filename;
					openFilename.lpstrFileTitle = fileTitle;
					openFilename.Flags = 0;

					if (GetOpenFileName(&openFilename)) {
						openFile = FindFileHandle(filename, FALSE);

						if (openFile) {
							playSelected = TRUE;
							result = FindSuitableOutputDevice(hwnd);

							if (result != MMSYSERR_NOERROR)
							{
								MessageBox(hWnd, "could not find suitable output device",
									"Error Message", MB_ICONSTOP | MB_OK);
								close(handle);
								exit(1);
							}

							EnableWindow(hwndButton[0], FALSE);
							EnableWindow(hwndButton[2], FALSE);
							SetWindowText((HWND)lParam, "Stop Playing");
						}
					}
				}
				else {
					stopped = TRUE;
					waveOutClose(waveOut);
					EnableWindow(hwndButton[0], TRUE);
					EnableWindow(hwndButton[2], TRUE);
					playSelected = playing = FALSE;
					audioLength = 0;
					SetWindowText((HWND)lParam, "Start Playing");
				}
			}
			else if (LOWORD(wParam) == 2) {
				if (recording == FALSE && recdSelected == FALSE)
				{
					BOOL openFile;
					MMRESULT result;

					InitializeOpenFilename(&openFilename);
					openFilename.lpstrFile = filename;
					openFilename.lpstrFileTitle = fileTitle;
					openFilename.Flags = OFN_OVERWRITEPROMPT;

					if (GetOpenFileName(&openFilename)) {
						openFile = FindFileHandle(filename, TRUE);

						if (openFile) {
							recdSelected = TRUE;
							result = FindSuitableInputDevice(hwnd);

							if (result != MMSYSERR_NOERROR)
							{
								MessageBox(hWnd, "could not find suitable input device",
									"Error Message", MB_ICONSTOP | MB_OK);
								close(handle);
								exit(1);
							}

							EnableWindow(hwndButton[0], FALSE);
							EnableWindow(hwndButton[1], FALSE);
							SetWindowText((HWND)lParam, "Stop Recording");
						}
					}
				}
				else {
					stopped = TRUE;
					waveInStop(waveIn);
					waveInClose(waveIn);
					EnableWindow(hwndButton[0], TRUE);
					EnableWindow(hwndButton[1], TRUE);
					recdSelected = FALSE;
					SetWindowText((HWND)lParam, "Start Recording");
				}
			}
			else if (LOWORD(wParam) == 3)
			{
				ClearWave(hwnd, buttonsY);
			}
			else if (LOWORD(wParam) == 4)
			{
				page = (page + 1) % maxPages;
				ClearWave(hwnd, buttonsY);
				DrawWave(hwnd, buttonsY);
			}
			else if (LOWORD(wParam) == 5)
			{
				page = (page - 1) % maxPages;
				if (page < 0)
					page = 0;
				ClearWave(hwnd, buttonsY);
				DrawWave(hwnd, buttonsY);
			}
			return 0;
		case WM_CREATE:
			/* create buttons */
			{
				int cxChar, cyChar, height, x, y;
				HDC hDC = GetDC(hwnd);
				RECT crect;
				TEXTMETRIC textMetric;

				GetTextMetrics(hDC, &textMetric);
				GetClientRect(hwnd, &crect);
				cxChar = textMetric.tmAveCharWidth;
				cyChar = textMetric.tmHeight + textMetric.tmExternalLeading;
				height = 8 * cyChar / 4;
				x = cxChar;
				y = cyChar;
				buttonsY = 4 * cyChar + height;
				for (i = 0; i < NUMBERBUTTONS; i++) {
					int width = 20 * cxChar;

					hwndButton[i] = CreateWindow("button", button[i].text,
						WS_CHILD | WS_VISIBLE | button[i].style, x, y, width, height,
						hwnd, (HMENU)i, ((LPCREATESTRUCT)lParam)->hInstance, NULL);
					x += width + 4 * cxChar;
				}
				InitializeCriticalSection(&cs);
				waveformat.cbSize = 0;
				waveformat.nAvgBytesPerSec = 44100 * 2 * 16 / 8;
				waveformat.nBlockAlign = 4;
				waveformat.nChannels = 2;
				waveformat.nSamplesPerSec = 44100;
				waveformat.wBitsPerSample = 16;
				waveformat.wFormatTag = WAVE_FORMAT_PCM;
			}
			return 0;
		case WM_DESTROY:
			if (playing)
			{
				waveOutClose(waveOut);
			}
			if (recording)
			{
				waveInStop(waveIn);
				waveInClose(waveIn);
			}
			PostQuitMessage(0);
			return 0;
		case WIM_CLOSE:
			if (recording)
			{
				EnterCriticalSection(&cs);
				recording = FALSE;
				stopped = FALSE;
				WriteAudioCDRIFFFile();
				LeaveCriticalSection(&cs);
			}
			return 0;
		case WIM_DATA:
			if (recording)
			{
				EnterCriticalSection(&cs);
				for (i = 0; i < waveHeader.dwBytesRecorded; i++)
					audioCaptureBuffer[audioLength + i] = waveHeader.lpData[i];
				audioLength = (audioLength + waveHeader.dwBytesRecorded) % acbSize;
				waveInAddBuffer(waveIn, &waveHeader, sizeof(waveHeader));
				LeaveCriticalSection(&cs);
			}
			return 0;
		case WIM_OPEN:
			if (recdSelected)
			{
				EnterCriticalSection(&cs);
				bzero(&waveHeader, sizeof(waveHeader))
				if (waveInPrepareHeader(waveIn, &waveHeader,
					sizeof(waveHeader)) != MMSYSERR_NOERROR)
				{
					MessageBox(hWnd, "could not prepare wave header",
						"Warning Message", MB_ICONWARNING | MB_OK);
					waveInClose(waveIn);
				}
				waveHeader.dwBufferLength = sizeof(waveHdrBuffer);
				waveHeader.lpData = waveHdrBuffer;
				bzero(&waveHdrBuffer, sizeof(waveHdrBuffer))
				LeaveCriticalSection(&cs);
				if (waveInStart(waveIn) != MMSYSERR_NOERROR)
				{
					MessageBox(hWnd, "could not start input device",
						"Warning Message", MB_ICONWARNING | MB_OK);
					waveInClose(waveIn);
				}
				EnterCriticalSection(&cs);
				if ((error = waveInAddBuffer(waveIn, &waveHeader,
					sizeof(waveHeader))) != MMSYSERR_NOERROR)
				{
					MessageBox(hWnd, "could not add buffer",
						"Warning Message", MB_ICONWARNING | MB_OK);
					waveInClose(waveIn);
				}
				LeaveCriticalSection(&cs);
				recording = TRUE;
				stopped = FALSE;
			}
			return 0;
		case WOM_CLOSE:
			if (playing)
			{
				EnterCriticalSection(&cs);
				playing = FALSE;
				stopped = FALSE;
				stopped = TRUE;
				waveOutClose(waveOut);
				EnableWindow(hwndButton[0], TRUE);
				EnableWindow(hwndButton[2], TRUE);
				playSelected = FALSE;
				SetWindowText((HWND)lParam, "Start Playing");
				LeaveCriticalSection(&cs);
			}
			return 0;
		case WOM_DONE:
			if (playing)
			{
				EnterCriticalSection(&cs);
				if (audioPtr + sizeof(waveHdrBuffer) < audioLength)
					playLength = sizeof(waveHdrBuffer);
				else
					playLength = audioLength % sizeof(waveHdrBuffer);
				for (i = 0; i < playLength; i++)
					waveHeader.lpData[i] = audioCaptureBuffer[audioPtr + i];
				waveHeader.dwBufferLength = playLength;
				waveOutWrite(waveOut, &waveHeader, sizeof(waveHeader));
				audioPtr += playLength;
				LeaveCriticalSection(&cs);
			}
			return 0;
		case WOM_OPEN:
			if (playSelected)
			{
				if ((error = ReadAudioCDRIFFFile()) != NoError)
				{
					MessageBox(hWnd, "could not read RIFF Wave File",
						"Error Message", MB_ICONSTOP | MB_OK);
					close(handle);
					exit(1);
				}
				EnterCriticalSection(&cs);
				if (waveOutPrepareHeader(waveOut, &waveHeader,
					sizeof(waveHeader)) != MMSYSERR_NOERROR)
				{
					MessageBox(hWnd, "could not prepare wave header",
						"Warning Message", MB_ICONWARNING | MB_OK);
					waveOutClose(waveOut);
				}
				waveHeader.lpData = waveHdrBuffer;
				if (audioPtr + sizeof(waveHdrBuffer) < audioLength)
					playLength = sizeof(waveHdrBuffer);
				else
					playLength = audioLength % sizeof(waveHdrBuffer);
				for (i = 0; i < playLength; i++)
					waveHeader.lpData[i] = audioCaptureBuffer[audioPtr + i];
				waveHeader.dwBufferLength = playLength;
				if ((error = waveOutWrite(waveOut, &waveHeader,
					sizeof(waveHeader))) != MMSYSERR_NOERROR)
				{
					MessageBox(hWnd, "could not add buffer",
						"Warning Message", MB_ICONWARNING | MB_OK);
					waveOutClose(waveOut);
				}
				audioPtr += playLength;
				LeaveCriticalSection(&cs);
				playing = TRUE;
				stopped = FALSE;
			}
			return 0;
	}
	return DefWindowProc(hwnd, iMsg, wParam, lParam);
}

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,
				   PSTR szCmdLine, int iCmdShow) {
	static char szAppName[] = "Audio Capture And Playing RIFF Wave File";
	static char title[] = "Win32 Audio Capture Etc. by James Pate Williams, Jr. (c) 2016";
	MSG msg;
	WNDCLASSEX  wndclass;

	wndclass.cbSize        = sizeof (wndclass);
	wndclass.style         = CS_HREDRAW | CS_VREDRAW;
	wndclass.lpfnWndProc   = WndProc;
	wndclass.cbClsExtra    = 0;
	wndclass.cbWndExtra    = 0;
	wndclass.hInstance     = hInstance;
	wndclass.hIcon         = NULL;
	wndclass.hCursor       = LoadCursor (NULL, IDC_ARROW);
	wndclass.hbrBackground = (HBRUSH) GetStockObject(WHITE_BRUSH);
	wndclass.lpszMenuName  = NULL;
	wndclass.lpszClassName = szAppName;
	wndclass.hIconSm       = NULL;
	RegisterClassEx (&wndclass);
	hWnd = CreateWindow(szAppName, title, WS_OVERLAPPEDWINDOW,
						CW_USEDEFAULT, CW_USEDEFAULT, UW_WIDTH, UW_HEIGHT,
						NULL, NULL, hInstance, NULL);
	hInst = hInstance;
	ShowWindow(hWnd, iCmdShow);
	UpdateWindow(hWnd) ;
	while (GetMessage(&msg, NULL, 0, 0)) {
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return msg.wParam;
}