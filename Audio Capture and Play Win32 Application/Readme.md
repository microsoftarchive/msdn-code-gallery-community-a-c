# Audio Capture and Play Win32 Application
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Win32
- C++
## Topics
- C++
- RIFF Wave File Processing
- Critical Section
- Audio Capture
## Updated
- 05/10/2016
## Description

<h1>Introduction</h1>
<p><em>This application captures, draws, and plays Resource Interchange File Format (RIFF) audio wave files. The RIFF file format consists of varying length chunkss that have the form: chunk identifier, chunk size in bytes, and chunk data. A RIFF audio wave
 file has a RIFF chunk, a format chunk, a junk chunk, and a audio data chunk.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>This project should build as is using Visual Studio 2015 Professional.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The application has six buttons labeled: &quot;Draw Wave File&quot;, &quot;Start Playing&quot;, &quot;Start Recording&quot;, &quot;Clear Wave Drawing&quot;, &quot;Wave Data Page Up&quot;, and &quot;Wave Data Page Dn&quot;. The first, fifth, and sixth push-buttons control the drawing of the wave audio data is
 unsigned characters (range -128 to &#43;127). The recording buffer is ten minutes long. To record set your sound card so that line in is CD quality (44100&nbsp;samples per second, 16 bits, 2 channels).&nbsp;I leave it up to the user to modify the code to handle
 DVD quality audio <em>(48000&nbsp;samples per second, 16 bits, 2 channels). You have to manually stop the playing. I leave automatic stopping of the audio stream as an assingment for interested users. The application is written in Win32 vanilla C and the main
 source code file is a mere 717 essentially monolithic lines of code which is quite short by Win32 standards.</em></em></p>
<p><em><img id="152825" width="998" height="793" src="152825-audiocaptureandplay%201.png" alt=""><img id="152826" width="998" height="793" src="152826-audiocaptureandplay%202.png" alt=""> &nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">/*
	Author: James Pate Williams, Jr. (c) 2016

	Audio Capture to RIFF Wave File
*/

#include &lt;fcntl.h&gt;
#include &lt;io.h&gt;
#include &lt;string.h&gt;
#include &lt;time.h&gt;
#include &lt;windows.h&gt;
#include &lt;commdlg.h&gt;
#include &lt;winsock.h&gt;
#include &lt;mmsystem.h&gt;
#include &lt;process.h&gt;
#include &lt;stdlib.h&gt;
#include &lt;sys\stat.h&gt;
#include &quot;resource.h&quot;

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
	static char szFilter[] = &quot;WAVE Files (*.wav)\0*.wav\0\0&quot;;

	memset(openFilename, 0, sizeof(*openFilename));
	openFilename-&gt;lStructSize = sizeof(*openFilename);
	openFilename-&gt;lpstrFilter = szFilter;
	openFilename-&gt;nMaxFile = _MAX_PATH;
	openFilename-&gt;nMaxFileTitle = _MAX_FNAME &#43; _MAX_EXT;
}

BOOL FindFileHandle(char *filename, BOOL output) {

	if (output)
		handle = open(filename, O_BINARY | O_WRONLY | O_CREAT | O_TRUNC, S_IWRITE);
	else
		handle = open(filename, O_BINARY | O_RDONLY, S_IREAD);

	if (handle == - 1) {
		MessageBox(hWnd, &quot;can't open file&quot;, &quot;Warning Message&quot;,
			MB_ICONEXCLAMATION | MB_OK);
		return FALSE;
	}
	return TRUE;
}

MMRESULT FindSuitableInputDevice(HWND hwndProc)
{
	return waveInOpen(&amp;waveIn, WAVE_MAPPER, &amp;waveformat, hwndProc, 
		hInst, CALLBACK_WINDOW);
}

MMRESULT FindSuitableOutputDevice(HWND hwndProc)
{
	return waveOutOpen(&amp;waveOut, WAVE_MAPPER, &amp;waveformat, hwndProc,
		hInst, CALLBACK_WINDOW);
}

BOOL EqualBuffer(BYTE *buffer1, BYTE *buffer2, int length)
{
	BOOL equal = TRUE;
	int i;

	for (i = 0; equal &amp;&amp; i &lt; length; i&#43;&#43;)
		equal = buffer1[i] == buffer2[i];

	return equal;
}

void ClearWave(HWND hwnd, int buttonsY)
{
	HBRUSH wb = (HBRUSH)GetStockObject(WHITE_BRUSH);
	HDC hdc = GetDC(hwnd);
	RECT r, rect;

	GetClientRect(hwnd, &amp;rect);

	r = rect;
	r.top = rect.top &#43; buttonsY;
	
	FillRect(hdc, &amp;r, wb);
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

	GetClientRect(hwnd, &amp;rect);

	width = rect.right - rect.left;
	height = rect.bottom - rect.top - buttonsY;
	xMin = 0;
	xMax = width - 1;
	yMin = height - 1;
	yMax = buttonsY;

	dMin = &#43;127;
	dMax = -128;
	iMin = 0;
	iMax = 256;

	for (i = 0; i &lt; audioLength; i&#43;&#43;)
	{
		signed char bb = audioCaptureBuffer[i];

		if (bb &lt; dMin)
			dMin = bb;

		if (bb &gt; dMax)
			dMax = bb;
	}

	xSlope = 1.0 / ((double)(iMax - iMin) / (xMax - xMin));
	ySlope = 1.0 / ((double)(dMax - dMin) / (yMin - yMax));
	xInter = xMin - xSlope * iMin;
	yInter = yMax - ySlope * dMin;
	
	for (i = 0; i &lt; iMax; i&#43;&#43;)
	{
		signed char d = audioCaptureBuffer[256 * page &#43; i];
		int x = (int)(xSlope * i &#43; xInter);
		int y = (int)(ySlope * d &#43; yInter);

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

	read(handle, &amp;cbSizeFile, sizeof(cbSizeFile));

	if (cbSizeFile &lt; 0)
		return cbSizeFileCorrupt;

	read(handle, WAVE, 4);

	if (!EqualBuffer(wave, WAVE, 4))
		return WAVECorrupt;

	read(handle, FMT_, 4);

	if (!EqualBuffer(fmt_, FMT_, 4))
		return fmt_Corrupt;

	read(handle, &amp;cbSizeSubChunk, sizeof(cbSizeSubChunk));

	if (cbSizeSubChunk != 18)
		return cbSizeSubChunkCorrupt;

	read(handle, &amp;audioFormat, sizeof(audioFormat));

	if (audioFormat != WAVE_FORMAT_PCM)
		return AudioFormatError;

	read(handle, &amp;numChannels, sizeof(numChannels));

	if (numChannels != 2)
		return NumChannelsError;

	read(handle, &amp;sampleRate, sizeof(sampleRate));

	if (sampleRate != 44100)
		return SampleRateError;

	read(handle, &amp;byteRate, sizeof(byteRate));

	if (byteRate != 44100 * 2 * 16 / 8)
		return ByteRateError;

	read(handle, &amp;blockAlign, sizeof(blockAlign));

	if (blockAlign != 4)
		return BlockAlignError;

	read(handle, &amp;bitsPerSample, sizeof(bitsPerSample));

	if (bitsPerSample != 16)
		return BitsPerSampleError;

	read(handle, &amp;pad, sizeof(pad));

	for (x = 0; x &lt; 4096; x&#43;&#43;)
		junkBuffer[x] = 0;

	read(handle, JUNK, 4);

	if (!EqualBuffer(junk, JUNK, 4))
		return JUNKCorrupt;

	read(handle, &amp;cbSizeJunk, sizeof(cbSizeJunk));

	if (cbSizeJunk &lt; 0 || cbSizeJunk &gt; 4096)
		return cbSizeJunkCorrupt;

	read(handle, junkBuffer, cbSizeJunk);

	read(handle, DATA, 4);

	if (!EqualBuffer(data, DATA, 4))
		return DATACorrupt;

	read(handle, &amp;audioLength, sizeof(audioLength));

	if (audioLength &lt; 0 || audioLength &gt; acbSize)
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

	for (x = audioLength; x &lt; audioLength &#43; 4096; x&#43;&#43;)
	{
		k = (x &#43; 54) % 4096;

		if (k == 0)
		{
			junkSize = (x &#43; 46) % 4096 - 46;
			chunkSize = audioLength &#43; (x &#43; 46) % 4096;
			break;
		}
	}

	write(handle, riff, 4);
	write(handle, &amp;chunkSize, sizeof(chunkSize));
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

	write(handle, &amp;subChunkSize1, sizeof(subChunkSize1));
	write(handle, &amp;audioFormat, sizeof(audioFormat));
	write(handle, &amp;numChannels, sizeof(numChannels));
	write(handle, &amp;sampleRate, sizeof(sampleRate));
	write(handle, &amp;byteRate, sizeof(byteRate));
	write(handle, &amp;blockAlign, sizeof(blockAlign));
	write(handle, &amp;bitsPerSample, sizeof(bitsPerSample));
	write(handle, &amp;pad, sizeof(pad));

	for (x = 0; x &lt; junkSize; x&#43;&#43;)
		junkBuffer[x] = 0;

	write(handle, junk, 4);
	write(handle, &amp;junkSize, sizeof(junkSize));

	write(handle, junkBuffer, junkSize);

	write(handle, data, 4);
	write(handle, &amp;audioLength, sizeof(audioLength));
	
	write(handle, audioCaptureBuffer, audioLength);
	close(handle);
}

LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam) {
	char none[32];
	enum ReadCDRIFFWaveFileError error;
	struct {
		long style;
		char *text;
	} button[] = { { BS_PUSHBUTTON, &quot;Draw Wave Data&quot; },
				   { BS_PUSHBUTTON, &quot;Start Playing&quot;},
				   { BS_PUSHBUTTON, &quot;Start Recording&quot; },
				   { BS_PUSHBUTTON, &quot;Clear Wave Drawing&quot; },
				   { BS_PUSHBUTTON, &quot;Wave Data Page Up&quot;  },
				   { BS_PUSHBUTTON, &quot;Wave Data Page Dn&quot;  }
	};
	DWORD dWord1 = 0, dWord2 = 0;
	HDC hdc;
	PAINTSTRUCT ps;
	RECT rect;
	UINT cbWaveHeader, count = 0, i, nDevices, uMessage = 0;
	WSADATA wsaData;
	OPENFILENAME openFilename;
	MMRESULT result;
	static char filename[_MAX_FNAME &#43; 1] = {'\0'};
	static char fileTitle[_MAX_FNAME &#43; _MAX_EXT &#43; 1] = {'\0'};
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

				InitializeOpenFilename(&amp;openFilename);
				openFilename.lpstrFile = filename;
				openFilename.lpstrFileTitle = fileTitle;
				openFilename.Flags = 0;

				if (GetOpenFileName(&amp;openFilename)) {
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
				if (playing == FALSE &amp;&amp; playSelected == FALSE)
				{
					BOOL openFile;
					MMRESULT result;

					InitializeOpenFilename(&amp;openFilename);
					openFilename.lpstrFile = filename;
					openFilename.lpstrFileTitle = fileTitle;
					openFilename.Flags = 0;

					if (GetOpenFileName(&amp;openFilename)) {
						openFile = FindFileHandle(filename, FALSE);

						if (openFile) {
							playSelected = TRUE;
							result = FindSuitableOutputDevice(hwnd);

							if (result != MMSYSERR_NOERROR)
							{
								MessageBox(hWnd, &quot;could not find suitable output device&quot;,
									&quot;Error Message&quot;, MB_ICONSTOP | MB_OK);
								close(handle);
								exit(1);
							}

							EnableWindow(hwndButton[0], FALSE);
							EnableWindow(hwndButton[2], FALSE);
							SetWindowText((HWND)lParam, &quot;Stop Playing&quot;);
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
					SetWindowText((HWND)lParam, &quot;Start Playing&quot;);
				}
			}
			else if (LOWORD(wParam) == 2) {
				if (recording == FALSE &amp;&amp; recdSelected == FALSE)
				{
					BOOL openFile;
					MMRESULT result;

					InitializeOpenFilename(&amp;openFilename);
					openFilename.lpstrFile = filename;
					openFilename.lpstrFileTitle = fileTitle;
					openFilename.Flags = OFN_OVERWRITEPROMPT;

					if (GetOpenFileName(&amp;openFilename)) {
						openFile = FindFileHandle(filename, TRUE);

						if (openFile) {
							recdSelected = TRUE;
							result = FindSuitableInputDevice(hwnd);

							if (result != MMSYSERR_NOERROR)
							{
								MessageBox(hWnd, &quot;could not find suitable input device&quot;,
									&quot;Error Message&quot;, MB_ICONSTOP | MB_OK);
								close(handle);
								exit(1);
							}

							EnableWindow(hwndButton[0], FALSE);
							EnableWindow(hwndButton[1], FALSE);
							SetWindowText((HWND)lParam, &quot;Stop Recording&quot;);
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
					SetWindowText((HWND)lParam, &quot;Start Recording&quot;);
				}
			}
			else if (LOWORD(wParam) == 3)
			{
				ClearWave(hwnd, buttonsY);
			}
			else if (LOWORD(wParam) == 4)
			{
				page = (page &#43; 1) % maxPages;
				ClearWave(hwnd, buttonsY);
				DrawWave(hwnd, buttonsY);
			}
			else if (LOWORD(wParam) == 5)
			{
				page = (page - 1) % maxPages;
				if (page &lt; 0)
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

				GetTextMetrics(hDC, &amp;textMetric);
				GetClientRect(hwnd, &amp;crect);
				cxChar = textMetric.tmAveCharWidth;
				cyChar = textMetric.tmHeight &#43; textMetric.tmExternalLeading;
				height = 8 * cyChar / 4;
				x = cxChar;
				y = cyChar;
				buttonsY = 4 * cyChar &#43; height;
				for (i = 0; i &lt; NUMBERBUTTONS; i&#43;&#43;) {
					int width = 20 * cxChar;

					hwndButton[i] = CreateWindow(&quot;button&quot;, button[i].text,
						WS_CHILD | WS_VISIBLE | button[i].style, x, y, width, height,
						hwnd, (HMENU)i, ((LPCREATESTRUCT)lParam)-&gt;hInstance, NULL);
					x &#43;= width &#43; 4 * cxChar;
				}
				InitializeCriticalSection(&amp;cs);
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
				EnterCriticalSection(&amp;cs);
				recording = FALSE;
				stopped = FALSE;
				WriteAudioCDRIFFFile();
				LeaveCriticalSection(&amp;cs);
			}
			return 0;
		case WIM_DATA:
			if (recording)
			{
				EnterCriticalSection(&amp;cs);
				for (i = 0; i &lt; waveHeader.dwBytesRecorded; i&#43;&#43;)
					audioCaptureBuffer[audioLength &#43; i] = waveHeader.lpData[i];
				audioLength = (audioLength &#43; waveHeader.dwBytesRecorded) % acbSize;
				waveInAddBuffer(waveIn, &amp;waveHeader, sizeof(waveHeader));
				LeaveCriticalSection(&amp;cs);
			}
			return 0;
		case WIM_OPEN:
			if (recdSelected)
			{
				EnterCriticalSection(&amp;cs);
				bzero(&amp;waveHeader, sizeof(waveHeader))
				if (waveInPrepareHeader(waveIn, &amp;waveHeader,
					sizeof(waveHeader)) != MMSYSERR_NOERROR)
				{
					MessageBox(hWnd, &quot;could not prepare wave header&quot;,
						&quot;Warning Message&quot;, MB_ICONWARNING | MB_OK);
					waveInClose(waveIn);
				}
				waveHeader.dwBufferLength = sizeof(waveHdrBuffer);
				waveHeader.lpData = waveHdrBuffer;
				bzero(&amp;waveHdrBuffer, sizeof(waveHdrBuffer))
				LeaveCriticalSection(&amp;cs);
				if (waveInStart(waveIn) != MMSYSERR_NOERROR)
				{
					MessageBox(hWnd, &quot;could not start input device&quot;,
						&quot;Warning Message&quot;, MB_ICONWARNING | MB_OK);
					waveInClose(waveIn);
				}
				EnterCriticalSection(&amp;cs);
				if ((error = waveInAddBuffer(waveIn, &amp;waveHeader,
					sizeof(waveHeader))) != MMSYSERR_NOERROR)
				{
					MessageBox(hWnd, &quot;could not add buffer&quot;,
						&quot;Warning Message&quot;, MB_ICONWARNING | MB_OK);
					waveInClose(waveIn);
				}
				LeaveCriticalSection(&amp;cs);
				recording = TRUE;
				stopped = FALSE;
			}
			return 0;
		case WOM_CLOSE:
			if (playing)
			{
				EnterCriticalSection(&amp;cs);
				playing = FALSE;
				stopped = FALSE;
				stopped = TRUE;
				waveOutClose(waveOut);
				EnableWindow(hwndButton[0], TRUE);
				EnableWindow(hwndButton[2], TRUE);
				playSelected = FALSE;
				SetWindowText((HWND)lParam, &quot;Start Playing&quot;);
				LeaveCriticalSection(&amp;cs);
			}
			return 0;
		case WOM_DONE:
			if (playing)
			{
				EnterCriticalSection(&amp;cs);
				if (audioPtr &#43; sizeof(waveHdrBuffer) &lt; audioLength)
					playLength = sizeof(waveHdrBuffer);
				else
					playLength = audioLength % sizeof(waveHdrBuffer);
				for (i = 0; i &lt; playLength; i&#43;&#43;)
					waveHeader.lpData[i] = audioCaptureBuffer[audioPtr &#43; i];
				waveHeader.dwBufferLength = playLength;
				waveOutWrite(waveOut, &amp;waveHeader, sizeof(waveHeader));
				audioPtr &#43;= playLength;
				LeaveCriticalSection(&amp;cs);
			}
			return 0;
		case WOM_OPEN:
			if (playSelected)
			{
				if ((error = ReadAudioCDRIFFFile()) != NoError)
				{
					MessageBox(hWnd, &quot;could not read RIFF Wave File&quot;,
						&quot;Error Message&quot;, MB_ICONSTOP | MB_OK);
					close(handle);
					exit(1);
				}
				EnterCriticalSection(&amp;cs);
				if (waveOutPrepareHeader(waveOut, &amp;waveHeader,
					sizeof(waveHeader)) != MMSYSERR_NOERROR)
				{
					MessageBox(hWnd, &quot;could not prepare wave header&quot;,
						&quot;Warning Message&quot;, MB_ICONWARNING | MB_OK);
					waveOutClose(waveOut);
				}
				waveHeader.lpData = waveHdrBuffer;
				if (audioPtr &#43; sizeof(waveHdrBuffer) &lt; audioLength)
					playLength = sizeof(waveHdrBuffer);
				else
					playLength = audioLength % sizeof(waveHdrBuffer);
				for (i = 0; i &lt; playLength; i&#43;&#43;)
					waveHeader.lpData[i] = audioCaptureBuffer[audioPtr &#43; i];
				waveHeader.dwBufferLength = playLength;
				if ((error = waveOutWrite(waveOut, &amp;waveHeader,
					sizeof(waveHeader))) != MMSYSERR_NOERROR)
				{
					MessageBox(hWnd, &quot;could not add buffer&quot;,
						&quot;Warning Message&quot;, MB_ICONWARNING | MB_OK);
					waveOutClose(waveOut);
				}
				audioPtr &#43;= playLength;
				LeaveCriticalSection(&amp;cs);
				playing = TRUE;
				stopped = FALSE;
			}
			return 0;
	}
	return DefWindowProc(hwnd, iMsg, wParam, lParam);
}

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,
				   PSTR szCmdLine, int iCmdShow) {
	static char szAppName[] = &quot;Audio Capture And Playing RIFF Wave File&quot;;
	static char title[] = &quot;Win32 Audio Capture Etc. by James Pate Williams, Jr. (c) 2016&quot;;
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
	RegisterClassEx (&amp;wndclass);
	hWnd = CreateWindow(szAppName, title, WS_OVERLAPPEDWINDOW,
						CW_USEDEFAULT, CW_USEDEFAULT, UW_WIDTH, UW_HEIGHT,
						NULL, NULL, hInstance, NULL);
	hInst = hInstance;
	ShowWindow(hWnd, iCmdShow);
	UpdateWindow(hWnd) ;
	while (GetMessage(&amp;msg, NULL, 0, 0)) {
		TranslateMessage(&amp;msg);
		DispatchMessage(&amp;msg);
	}
	return msg.wParam;
}</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__mlcom">/*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Author:&nbsp;James&nbsp;Pate&nbsp;Williams,&nbsp;Jr.&nbsp;(c)&nbsp;2016&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Audio&nbsp;Capture&nbsp;to&nbsp;RIFF&nbsp;Wave&nbsp;File&nbsp;
*/</span><span class="cpp__preproc">&nbsp;
&nbsp;
#include&nbsp;&lt;fcntl.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;io.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;string.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;time.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;windows.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;commdlg.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;winsock.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;mmsystem.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;process.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;stdlib.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;sys\stat.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;resource.h&quot;</span><span class="cpp__preproc">&nbsp;
&nbsp;
#define&nbsp;NUMBERBUTTONS&nbsp;6</span><span class="cpp__preproc">&nbsp;
#define&nbsp;ACBSIZE&nbsp;2&nbsp;*&nbsp;44100&nbsp;*&nbsp;60&nbsp;*&nbsp;15</span><span class="cpp__preproc">&nbsp;
#define&nbsp;UW_WIDTH&nbsp;1012</span><span class="cpp__preproc">&nbsp;
#define&nbsp;UW_HEIGHT&nbsp;800</span><span class="cpp__preproc">&nbsp;
#define&nbsp;bzero(s,&nbsp;n)&nbsp;memset((s),&nbsp;0,&nbsp;(n));</span>&nbsp;
&nbsp;
<span class="cpp__datatype">char</span>&nbsp;copyright[<span class="cpp__number">256</span>],&nbsp;title[<span class="cpp__number">256</span>];&nbsp;
<span class="cpp__datatype">char</span>&nbsp;data[<span class="cpp__number">4</span>]&nbsp;=&nbsp;{&nbsp;<span class="cpp__string">'d'</span>,&nbsp;<span class="cpp__string">'a'</span>,&nbsp;<span class="cpp__string">'t'</span>,&nbsp;<span class="cpp__string">'a'</span>&nbsp;};&nbsp;
<span class="cpp__datatype">char</span>&nbsp;fmt_[<span class="cpp__number">4</span>]&nbsp;=&nbsp;{&nbsp;<span class="cpp__string">'f'</span>,&nbsp;<span class="cpp__string">'m'</span>,&nbsp;<span class="cpp__string">'t'</span>,&nbsp;<span class="cpp__string">'&nbsp;'</span>&nbsp;};&nbsp;
<span class="cpp__datatype">char</span>&nbsp;junk[<span class="cpp__number">4</span>]&nbsp;=&nbsp;{&nbsp;<span class="cpp__string">'J'</span>,&nbsp;<span class="cpp__string">'U'</span>,&nbsp;<span class="cpp__string">'N'</span>,&nbsp;<span class="cpp__string">'K'</span>&nbsp;};&nbsp;
<span class="cpp__datatype">char</span>&nbsp;riff[<span class="cpp__number">4</span>]&nbsp;=&nbsp;{&nbsp;<span class="cpp__string">'R'</span>,&nbsp;<span class="cpp__string">'I'</span>,&nbsp;<span class="cpp__string">'F'</span>,&nbsp;<span class="cpp__string">'F'</span>&nbsp;};&nbsp;
<span class="cpp__datatype">char</span>&nbsp;wave[<span class="cpp__number">4</span>]&nbsp;=&nbsp;{&nbsp;<span class="cpp__string">'W'</span>,&nbsp;<span class="cpp__string">'A'</span>,&nbsp;<span class="cpp__string">'V'</span>,&nbsp;<span class="cpp__string">'E'</span>&nbsp;};&nbsp;
<span class="cpp__datatype">int</span>&nbsp;handle&nbsp;=&nbsp;-<span class="cpp__number">1</span>,&nbsp;audioLength&nbsp;=&nbsp;<span class="cpp__number">0</span>,&nbsp;audioPtr&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
<span class="cpp__datatype">int</span>&nbsp;acbSize&nbsp;=&nbsp;ACBSIZE,&nbsp;fileCount,&nbsp;page;&nbsp;
<span class="cpp__keyword">enum</span>&nbsp;ReadCDRIFFWaveFileError&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;NoError&nbsp;=&nbsp;<span class="cpp__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RIFFCorrupt&nbsp;=&nbsp;<span class="cpp__number">1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cbSizeFileCorrupt&nbsp;=&nbsp;<span class="cpp__number">2</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WAVECorrupt&nbsp;=&nbsp;<span class="cpp__number">3</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;fmt_Corrupt&nbsp;=&nbsp;<span class="cpp__number">4</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cbSizeSubChunkCorrupt&nbsp;=&nbsp;<span class="cpp__number">5</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AudioFormatError&nbsp;=&nbsp;<span class="cpp__number">6</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;NumChannelsError&nbsp;=&nbsp;<span class="cpp__number">7</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SampleRateError&nbsp;=&nbsp;<span class="cpp__number">8</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ByteRateError&nbsp;=&nbsp;<span class="cpp__number">9</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BlockAlignError&nbsp;=&nbsp;<span class="cpp__number">10</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BitsPerSampleError&nbsp;=&nbsp;<span class="cpp__number">11</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;JUNKCorrupt&nbsp;=&nbsp;<span class="cpp__number">12</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cbSizeJunkCorrupt&nbsp;=&nbsp;<span class="cpp__number">13</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DATACorrupt&nbsp;=&nbsp;<span class="cpp__number">14</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AudioLengthError&nbsp;=&nbsp;<span class="cpp__number">15</span>&nbsp;
};&nbsp;
<span class="cpp__datatype">BOOL</span>&nbsp;drawSelected&nbsp;=&nbsp;FALSE,&nbsp;playSelected&nbsp;=&nbsp;FALSE,&nbsp;recdSelected&nbsp;=&nbsp;FALSE;&nbsp;
<span class="cpp__datatype">BOOL</span>&nbsp;recording&nbsp;=&nbsp;FALSE,&nbsp;playing&nbsp;=&nbsp;FALSE,&nbsp;stopped&nbsp;=&nbsp;FALSE;&nbsp;
<span class="cpp__datatype">BYTE</span>&nbsp;audioCaptureBuffer[ACBSIZE];&nbsp;
<span class="cpp__datatype">BYTE</span>&nbsp;waveHdrBuffer[<span class="cpp__number">2</span>&nbsp;*&nbsp;<span class="cpp__number">44100</span>];&nbsp;
CRITICAL_SECTION&nbsp;cs;&nbsp;
<span class="cpp__datatype">HINSTANCE</span>&nbsp;hInst;&nbsp;
HWAVEIN&nbsp;waveIn;&nbsp;
HWAVEOUT&nbsp;waveOut;&nbsp;
<span class="cpp__datatype">HWND</span>&nbsp;hWnd;&nbsp;
<span class="cpp__datatype">HWND</span>&nbsp;hwndButton[NUMBERBUTTONS];&nbsp;
WAVEFORMATEX&nbsp;waveformat;&nbsp;
WAVEHDR&nbsp;waveHeader;&nbsp;
&nbsp;
<span class="cpp__keyword">void</span>&nbsp;InitializeOpenFilename(OPENFILENAME&nbsp;*openFilename)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__datatype">char</span>&nbsp;szFilter[]&nbsp;=&nbsp;<span class="cpp__string">&quot;WAVE&nbsp;Files&nbsp;(*.wav)\0*.wav\0\0&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;memset(openFilename,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__keyword">sizeof</span>(*openFilename));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;openFilename-&gt;lStructSize&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(*openFilename);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;openFilename-&gt;lpstrFilter&nbsp;=&nbsp;szFilter;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;openFilename-&gt;nMaxFile&nbsp;=&nbsp;_MAX_PATH;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;openFilename-&gt;nMaxFileTitle&nbsp;=&nbsp;_MAX_FNAME&nbsp;&#43;&nbsp;_MAX_EXT;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">BOOL</span>&nbsp;FindFileHandle(<span class="cpp__datatype">char</span>&nbsp;*filename,&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;output)&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(output)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;handle&nbsp;=&nbsp;open(filename,&nbsp;O_BINARY&nbsp;|&nbsp;O_WRONLY&nbsp;|&nbsp;O_CREAT&nbsp;|&nbsp;O_TRUNC,&nbsp;S_IWRITE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;handle&nbsp;=&nbsp;open(filename,&nbsp;O_BINARY&nbsp;|&nbsp;O_RDONLY,&nbsp;S_IREAD);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(handle&nbsp;==&nbsp;-&nbsp;<span class="cpp__number">1</span>)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hWnd,&nbsp;<span class="cpp__string">&quot;can't&nbsp;open&nbsp;file&quot;</span>,&nbsp;<span class="cpp__string">&quot;Warning&nbsp;Message&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MB_ICONEXCLAMATION&nbsp;|&nbsp;MB_OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;TRUE;&nbsp;
}&nbsp;
&nbsp;
MMRESULT&nbsp;FindSuitableInputDevice(<span class="cpp__datatype">HWND</span>&nbsp;hwndProc)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;waveInOpen(&amp;waveIn,&nbsp;WAVE_MAPPER,&nbsp;&amp;waveformat,&nbsp;hwndProc,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hInst,&nbsp;CALLBACK_WINDOW);&nbsp;
}&nbsp;
&nbsp;
MMRESULT&nbsp;FindSuitableOutputDevice(<span class="cpp__datatype">HWND</span>&nbsp;hwndProc)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;waveOutOpen(&amp;waveOut,&nbsp;WAVE_MAPPER,&nbsp;&amp;waveformat,&nbsp;hwndProc,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hInst,&nbsp;CALLBACK_WINDOW);&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">BOOL</span>&nbsp;EqualBuffer(<span class="cpp__datatype">BYTE</span>&nbsp;*buffer1,&nbsp;<span class="cpp__datatype">BYTE</span>&nbsp;*buffer2,&nbsp;<span class="cpp__datatype">int</span>&nbsp;length)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;equal&nbsp;=&nbsp;TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;i;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;equal&nbsp;&amp;&amp;&nbsp;i&nbsp;&lt;&nbsp;length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;equal&nbsp;=&nbsp;buffer1[i]&nbsp;==&nbsp;buffer2[i];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;equal;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__keyword">void</span>&nbsp;ClearWave(<span class="cpp__datatype">HWND</span>&nbsp;hwnd,&nbsp;<span class="cpp__datatype">int</span>&nbsp;buttonsY)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HBRUSH</span>&nbsp;wb&nbsp;=&nbsp;(<span class="cpp__datatype">HBRUSH</span>)GetStockObject(WHITE_BRUSH);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HDC</span>&nbsp;hdc&nbsp;=&nbsp;GetDC(hwnd);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RECT&nbsp;r,&nbsp;rect;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;GetClientRect(hwnd,&nbsp;&amp;rect);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;r&nbsp;=&nbsp;rect;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;r.top&nbsp;=&nbsp;rect.top&nbsp;&#43;&nbsp;buttonsY;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FillRect(hdc,&nbsp;&amp;r,&nbsp;wb);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ReleaseDC(hwnd,&nbsp;hdc);&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__keyword">void</span>&nbsp;DrawLine(<span class="cpp__datatype">HDC</span>&nbsp;hdc,&nbsp;<span class="cpp__datatype">int</span>&nbsp;x1,&nbsp;<span class="cpp__datatype">int</span>&nbsp;y1,&nbsp;<span class="cpp__datatype">int</span>&nbsp;x2,&nbsp;<span class="cpp__datatype">int</span>&nbsp;y2)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MoveToEx(hdc,&nbsp;x1,&nbsp;y1,&nbsp;NULL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;LineTo(hdc,&nbsp;x2,&nbsp;y2);&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__keyword">void</span>&nbsp;DrawWave(<span class="cpp__datatype">HWND</span>&nbsp;hwnd,&nbsp;<span class="cpp__datatype">int</span>&nbsp;buttonsY)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HDC</span>&nbsp;hdc&nbsp;=&nbsp;GetDC(hwnd);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RECT&nbsp;rect;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">double</span>&nbsp;xInter,&nbsp;xSlope;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">double</span>&nbsp;yInter,&nbsp;ySlope;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;i,&nbsp;width,&nbsp;height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;oldX,&nbsp;oldY;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;dMax,&nbsp;dMin;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;iMax,&nbsp;iMin;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;xMax,&nbsp;xMin;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;yMax,&nbsp;yMin;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;GetClientRect(hwnd,&nbsp;&amp;rect);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;width&nbsp;=&nbsp;rect.right&nbsp;-&nbsp;rect.left;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;height&nbsp;=&nbsp;rect.bottom&nbsp;-&nbsp;rect.top&nbsp;-&nbsp;buttonsY;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xMin&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xMax&nbsp;=&nbsp;width&nbsp;-&nbsp;<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;yMin&nbsp;=&nbsp;height&nbsp;-&nbsp;<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;yMax&nbsp;=&nbsp;buttonsY;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dMin&nbsp;=&nbsp;&#43;<span class="cpp__number">127</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dMax&nbsp;=&nbsp;-<span class="cpp__number">128</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;iMin&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;iMax&nbsp;=&nbsp;<span class="cpp__number">256</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;audioLength;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">signed</span>&nbsp;<span class="cpp__datatype">char</span>&nbsp;bb&nbsp;=&nbsp;audioCaptureBuffer[i];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(bb&nbsp;&lt;&nbsp;dMin)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dMin&nbsp;=&nbsp;bb;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(bb&nbsp;&gt;&nbsp;dMax)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dMax&nbsp;=&nbsp;bb;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xSlope&nbsp;=&nbsp;<span class="cpp__number">1.0</span>&nbsp;/&nbsp;((<span class="cpp__datatype">double</span>)(iMax&nbsp;-&nbsp;iMin)&nbsp;/&nbsp;(xMax&nbsp;-&nbsp;xMin));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ySlope&nbsp;=&nbsp;<span class="cpp__number">1.0</span>&nbsp;/&nbsp;((<span class="cpp__datatype">double</span>)(dMax&nbsp;-&nbsp;dMin)&nbsp;/&nbsp;(yMin&nbsp;-&nbsp;yMax));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xInter&nbsp;=&nbsp;xMin&nbsp;-&nbsp;xSlope&nbsp;*&nbsp;iMin;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;yInter&nbsp;=&nbsp;yMax&nbsp;-&nbsp;ySlope&nbsp;*&nbsp;dMin;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;iMax;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">signed</span>&nbsp;<span class="cpp__datatype">char</span>&nbsp;d&nbsp;=&nbsp;audioCaptureBuffer[<span class="cpp__number">256</span>&nbsp;*&nbsp;page&nbsp;&#43;&nbsp;i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;x&nbsp;=&nbsp;(<span class="cpp__datatype">int</span>)(xSlope&nbsp;*&nbsp;i&nbsp;&#43;&nbsp;xInter);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;y&nbsp;=&nbsp;(<span class="cpp__datatype">int</span>)(ySlope&nbsp;*&nbsp;d&nbsp;&#43;&nbsp;yInter);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(i&nbsp;==&nbsp;<span class="cpp__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oldX&nbsp;=&nbsp;x;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oldY&nbsp;=&nbsp;y;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">continue</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawLine(hdc,&nbsp;oldX,&nbsp;oldY,&nbsp;x,&nbsp;y);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oldX&nbsp;=&nbsp;x;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oldY&nbsp;=&nbsp;y;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ReleaseDC(hwnd,&nbsp;hdc);&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__keyword">enum</span>&nbsp;ReadCDRIFFFileError&nbsp;ReadAudioCDRIFFFile()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BYTE</span>&nbsp;DATA[<span class="cpp__number">4</span>],&nbsp;FMT_[<span class="cpp__number">4</span>],&nbsp;JUNK[<span class="cpp__number">4</span>],&nbsp;RIFF[<span class="cpp__number">4</span>],&nbsp;WAVE[<span class="cpp__number">4</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">char</span>&nbsp;junkBuffer[<span class="cpp__number">4096</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;cdSizeData,&nbsp;cbSizeFile,&nbsp;cbSizeJunk,&nbsp;cbSizeSubChunk,&nbsp;x;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">short</span>&nbsp;audioFormat;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">short</span>&nbsp;numChannels;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;sampleRate;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;byteRate;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">short</span>&nbsp;blockAlign;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">short</span>&nbsp;bitsPerSample;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">short</span>&nbsp;pad;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;RIFF,&nbsp;<span class="cpp__number">4</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!EqualBuffer(riff,&nbsp;RIFF,&nbsp;<span class="cpp__number">4</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;RIFFCorrupt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;&amp;cbSizeFile,&nbsp;<span class="cpp__keyword">sizeof</span>(cbSizeFile));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(cbSizeFile&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;cbSizeFileCorrupt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;WAVE,&nbsp;<span class="cpp__number">4</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!EqualBuffer(wave,&nbsp;WAVE,&nbsp;<span class="cpp__number">4</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;WAVECorrupt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;FMT_,&nbsp;<span class="cpp__number">4</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!EqualBuffer(fmt_,&nbsp;FMT_,&nbsp;<span class="cpp__number">4</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;fmt_Corrupt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;&amp;cbSizeSubChunk,&nbsp;<span class="cpp__keyword">sizeof</span>(cbSizeSubChunk));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(cbSizeSubChunk&nbsp;!=&nbsp;<span class="cpp__number">18</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;cbSizeSubChunkCorrupt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;&amp;audioFormat,&nbsp;<span class="cpp__keyword">sizeof</span>(audioFormat));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(audioFormat&nbsp;!=&nbsp;WAVE_FORMAT_PCM)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;AudioFormatError;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;&amp;numChannels,&nbsp;<span class="cpp__keyword">sizeof</span>(numChannels));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(numChannels&nbsp;!=&nbsp;<span class="cpp__number">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NumChannelsError;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;&amp;sampleRate,&nbsp;<span class="cpp__keyword">sizeof</span>(sampleRate));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(sampleRate&nbsp;!=&nbsp;<span class="cpp__number">44100</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;SampleRateError;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;&amp;byteRate,&nbsp;<span class="cpp__keyword">sizeof</span>(byteRate));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(byteRate&nbsp;!=&nbsp;<span class="cpp__number">44100</span>&nbsp;*&nbsp;<span class="cpp__number">2</span>&nbsp;*&nbsp;<span class="cpp__number">16</span>&nbsp;/&nbsp;<span class="cpp__number">8</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;ByteRateError;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;&amp;blockAlign,&nbsp;<span class="cpp__keyword">sizeof</span>(blockAlign));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(blockAlign&nbsp;!=&nbsp;<span class="cpp__number">4</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;BlockAlignError;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;&amp;bitsPerSample,&nbsp;<span class="cpp__keyword">sizeof</span>(bitsPerSample));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(bitsPerSample&nbsp;!=&nbsp;<span class="cpp__number">16</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;BitsPerSampleError;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;&amp;pad,&nbsp;<span class="cpp__keyword">sizeof</span>(pad));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(x&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;x&nbsp;&lt;&nbsp;<span class="cpp__number">4096</span>;&nbsp;x&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;junkBuffer[x]&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;JUNK,&nbsp;<span class="cpp__number">4</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!EqualBuffer(junk,&nbsp;JUNK,&nbsp;<span class="cpp__number">4</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;JUNKCorrupt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;&amp;cbSizeJunk,&nbsp;<span class="cpp__keyword">sizeof</span>(cbSizeJunk));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(cbSizeJunk&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>&nbsp;||&nbsp;cbSizeJunk&nbsp;&gt;&nbsp;<span class="cpp__number">4096</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;cbSizeJunkCorrupt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;junkBuffer,&nbsp;cbSizeJunk);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;DATA,&nbsp;<span class="cpp__number">4</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!EqualBuffer(data,&nbsp;DATA,&nbsp;<span class="cpp__number">4</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;DATACorrupt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;&amp;audioLength,&nbsp;<span class="cpp__keyword">sizeof</span>(audioLength));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(audioLength&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>&nbsp;||&nbsp;audioLength&nbsp;&gt;&nbsp;acbSize)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;AudioLengthError;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;read(handle,&nbsp;audioCaptureBuffer,&nbsp;audioLength);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;audioPtr&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;close(handle);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NoError;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__keyword">void</span>&nbsp;WriteAudioCDRIFFFile()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">char</span>&nbsp;junkBuffer[<span class="cpp__number">4096</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;chunkSize&nbsp;=&nbsp;<span class="cpp__number">0</span>,&nbsp;junkSize&nbsp;=&nbsp;<span class="cpp__number">0</span>,&nbsp;k,&nbsp;x;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(x&nbsp;=&nbsp;audioLength;&nbsp;x&nbsp;&lt;&nbsp;audioLength&nbsp;&#43;&nbsp;<span class="cpp__number">4096</span>;&nbsp;x&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;k&nbsp;=&nbsp;(x&nbsp;&#43;&nbsp;<span class="cpp__number">54</span>)&nbsp;%&nbsp;<span class="cpp__number">4096</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(k&nbsp;==&nbsp;<span class="cpp__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;junkSize&nbsp;=&nbsp;(x&nbsp;&#43;&nbsp;<span class="cpp__number">46</span>)&nbsp;%&nbsp;<span class="cpp__number">4096</span>&nbsp;-&nbsp;<span class="cpp__number">46</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chunkSize&nbsp;=&nbsp;audioLength&nbsp;&#43;&nbsp;(x&nbsp;&#43;&nbsp;<span class="cpp__number">46</span>)&nbsp;%&nbsp;<span class="cpp__number">4096</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;riff,&nbsp;<span class="cpp__number">4</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;&amp;chunkSize,&nbsp;<span class="cpp__keyword">sizeof</span>(chunkSize));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;wave,&nbsp;<span class="cpp__number">4</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;fmt_,&nbsp;<span class="cpp__number">4</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;subChunkSize1&nbsp;=&nbsp;<span class="cpp__number">18</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">short</span>&nbsp;audioFormat&nbsp;=&nbsp;<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">short</span>&nbsp;numChannels&nbsp;=&nbsp;<span class="cpp__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;sampleRate&nbsp;=&nbsp;<span class="cpp__number">44100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;byteRate&nbsp;=&nbsp;<span class="cpp__number">44100</span>&nbsp;*&nbsp;<span class="cpp__number">2</span>&nbsp;*&nbsp;<span class="cpp__number">16</span>&nbsp;/&nbsp;<span class="cpp__number">8</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">short</span>&nbsp;blockAlign&nbsp;=&nbsp;<span class="cpp__number">4</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">short</span>&nbsp;bitsPerSample&nbsp;=&nbsp;<span class="cpp__number">16</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">short</span>&nbsp;pad&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;&amp;subChunkSize1,&nbsp;<span class="cpp__keyword">sizeof</span>(subChunkSize1));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;&amp;audioFormat,&nbsp;<span class="cpp__keyword">sizeof</span>(audioFormat));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;&amp;numChannels,&nbsp;<span class="cpp__keyword">sizeof</span>(numChannels));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;&amp;sampleRate,&nbsp;<span class="cpp__keyword">sizeof</span>(sampleRate));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;&amp;byteRate,&nbsp;<span class="cpp__keyword">sizeof</span>(byteRate));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;&amp;blockAlign,&nbsp;<span class="cpp__keyword">sizeof</span>(blockAlign));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;&amp;bitsPerSample,&nbsp;<span class="cpp__keyword">sizeof</span>(bitsPerSample));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;&amp;pad,&nbsp;<span class="cpp__keyword">sizeof</span>(pad));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(x&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;x&nbsp;&lt;&nbsp;junkSize;&nbsp;x&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;junkBuffer[x]&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;junk,&nbsp;<span class="cpp__number">4</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;&amp;junkSize,&nbsp;<span class="cpp__keyword">sizeof</span>(junkSize));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;junkBuffer,&nbsp;junkSize);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;data,&nbsp;<span class="cpp__number">4</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;&amp;audioLength,&nbsp;<span class="cpp__keyword">sizeof</span>(audioLength));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;write(handle,&nbsp;audioCaptureBuffer,&nbsp;audioLength);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;close(handle);&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">LRESULT</span>&nbsp;CALLBACK&nbsp;WndProc(<span class="cpp__datatype">HWND</span>&nbsp;hwnd,&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;iMsg,&nbsp;<span class="cpp__datatype">WPARAM</span>&nbsp;wParam,&nbsp;<span class="cpp__datatype">LPARAM</span>&nbsp;lParam)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">char</span>&nbsp;none[<span class="cpp__number">32</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">enum</span>&nbsp;ReadCDRIFFWaveFileError&nbsp;error;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">struct</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">long</span>&nbsp;style;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">char</span>&nbsp;*text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;button[]&nbsp;=&nbsp;{&nbsp;{&nbsp;BS_PUSHBUTTON,&nbsp;<span class="cpp__string">&quot;Draw&nbsp;Wave&nbsp;Data&quot;</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;BS_PUSHBUTTON,&nbsp;<span class="cpp__string">&quot;Start&nbsp;Playing&quot;</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;BS_PUSHBUTTON,&nbsp;<span class="cpp__string">&quot;Start&nbsp;Recording&quot;</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;BS_PUSHBUTTON,&nbsp;<span class="cpp__string">&quot;Clear&nbsp;Wave&nbsp;Drawing&quot;</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;BS_PUSHBUTTON,&nbsp;<span class="cpp__string">&quot;Wave&nbsp;Data&nbsp;Page&nbsp;Up&quot;</span>&nbsp;&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;BS_PUSHBUTTON,&nbsp;<span class="cpp__string">&quot;Wave&nbsp;Data&nbsp;Page&nbsp;Dn&quot;</span>&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;dWord1&nbsp;=&nbsp;<span class="cpp__number">0</span>,&nbsp;dWord2&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HDC</span>&nbsp;hdc;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PAINTSTRUCT&nbsp;ps;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RECT&nbsp;rect;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;cbWaveHeader,&nbsp;count&nbsp;=&nbsp;<span class="cpp__number">0</span>,&nbsp;i,&nbsp;nDevices,&nbsp;uMessage&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WSADATA&nbsp;wsaData;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;OPENFILENAME&nbsp;openFilename;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MMRESULT&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__datatype">char</span>&nbsp;filename[_MAX_FNAME&nbsp;&#43;&nbsp;<span class="cpp__number">1</span>]&nbsp;=&nbsp;{<span class="cpp__string">'\0'</span>};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__datatype">char</span>&nbsp;fileTitle[_MAX_FNAME&nbsp;&#43;&nbsp;_MAX_EXT&nbsp;&#43;&nbsp;<span class="cpp__number">1</span>]&nbsp;=&nbsp;{<span class="cpp__string">'\0'</span>};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__datatype">int</span>&nbsp;cxClient,&nbsp;cyClient;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__datatype">int</span>&nbsp;buttonsY,&nbsp;j,&nbsp;chunkSize&nbsp;=&nbsp;<span class="cpp__number">0</span>,&nbsp;junkSize&nbsp;=&nbsp;<span class="cpp__number">0</span>,&nbsp;maxPages,&nbsp;playLength,&nbsp;x,&nbsp;y;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;mouseOn&nbsp;=&nbsp;FALSE,&nbsp;rf;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;RECT&nbsp;channelRect[<span class="cpp__number">16</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>&nbsp;(iMsg)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_COMMAND:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(LOWORD(wParam)&nbsp;==&nbsp;<span class="cpp__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;openFile;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MMRESULT&nbsp;result;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeOpenFilename(&amp;openFilename);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openFilename.lpstrFile&nbsp;=&nbsp;filename;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openFilename.lpstrFileTitle&nbsp;=&nbsp;fileTitle;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openFilename.Flags&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(GetOpenFileName(&amp;openFilename))&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openFile&nbsp;=&nbsp;FindFileHandle(filename,&nbsp;FALSE);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(openFile)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReadAudioCDRIFFFile();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;page&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;maxPages&nbsp;=&nbsp;audioLength&nbsp;/&nbsp;<span class="cpp__number">256</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawWave(hwnd,&nbsp;buttonsY);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>&nbsp;(LOWORD(wParam)&nbsp;==&nbsp;<span class="cpp__number">1</span>)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(playing&nbsp;==&nbsp;FALSE&nbsp;&amp;&amp;&nbsp;playSelected&nbsp;==&nbsp;FALSE)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;openFile;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MMRESULT&nbsp;result;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeOpenFilename(&amp;openFilename);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openFilename.lpstrFile&nbsp;=&nbsp;filename;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openFilename.lpstrFileTitle&nbsp;=&nbsp;fileTitle;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openFilename.Flags&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(GetOpenFileName(&amp;openFilename))&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openFile&nbsp;=&nbsp;FindFileHandle(filename,&nbsp;FALSE);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(openFile)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;playSelected&nbsp;=&nbsp;TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;FindSuitableOutputDevice(hwnd);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(result&nbsp;!=&nbsp;MMSYSERR_NOERROR)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hWnd,&nbsp;<span class="cpp__string">&quot;could&nbsp;not&nbsp;find&nbsp;suitable&nbsp;output&nbsp;device&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__string">&quot;Error&nbsp;Message&quot;</span>,&nbsp;MB_ICONSTOP&nbsp;|&nbsp;MB_OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;close(handle);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;exit(<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(hwndButton[<span class="cpp__number">0</span>],&nbsp;FALSE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(hwndButton[<span class="cpp__number">2</span>],&nbsp;FALSE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetWindowText((<span class="cpp__datatype">HWND</span>)lParam,&nbsp;<span class="cpp__string">&quot;Stop&nbsp;Playing&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stopped&nbsp;=&nbsp;TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveOutClose(waveOut);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(hwndButton[<span class="cpp__number">0</span>],&nbsp;TRUE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(hwndButton[<span class="cpp__number">2</span>],&nbsp;TRUE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;playSelected&nbsp;=&nbsp;playing&nbsp;=&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;audioLength&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetWindowText((<span class="cpp__datatype">HWND</span>)lParam,&nbsp;<span class="cpp__string">&quot;Start&nbsp;Playing&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>&nbsp;(LOWORD(wParam)&nbsp;==&nbsp;<span class="cpp__number">2</span>)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(recording&nbsp;==&nbsp;FALSE&nbsp;&amp;&amp;&nbsp;recdSelected&nbsp;==&nbsp;FALSE)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;openFile;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MMRESULT&nbsp;result;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeOpenFilename(&amp;openFilename);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openFilename.lpstrFile&nbsp;=&nbsp;filename;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openFilename.lpstrFileTitle&nbsp;=&nbsp;fileTitle;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openFilename.Flags&nbsp;=&nbsp;OFN_OVERWRITEPROMPT;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(GetOpenFileName(&amp;openFilename))&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openFile&nbsp;=&nbsp;FindFileHandle(filename,&nbsp;TRUE);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(openFile)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;recdSelected&nbsp;=&nbsp;TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;FindSuitableInputDevice(hwnd);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(result&nbsp;!=&nbsp;MMSYSERR_NOERROR)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hWnd,&nbsp;<span class="cpp__string">&quot;could&nbsp;not&nbsp;find&nbsp;suitable&nbsp;input&nbsp;device&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__string">&quot;Error&nbsp;Message&quot;</span>,&nbsp;MB_ICONSTOP&nbsp;|&nbsp;MB_OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;close(handle);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;exit(<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(hwndButton[<span class="cpp__number">0</span>],&nbsp;FALSE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(hwndButton[<span class="cpp__number">1</span>],&nbsp;FALSE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetWindowText((<span class="cpp__datatype">HWND</span>)lParam,&nbsp;<span class="cpp__string">&quot;Stop&nbsp;Recording&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stopped&nbsp;=&nbsp;TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveInStop(waveIn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveInClose(waveIn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(hwndButton[<span class="cpp__number">0</span>],&nbsp;TRUE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(hwndButton[<span class="cpp__number">1</span>],&nbsp;TRUE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;recdSelected&nbsp;=&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetWindowText((<span class="cpp__datatype">HWND</span>)lParam,&nbsp;<span class="cpp__string">&quot;Start&nbsp;Recording&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>&nbsp;(LOWORD(wParam)&nbsp;==&nbsp;<span class="cpp__number">3</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClearWave(hwnd,&nbsp;buttonsY);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>&nbsp;(LOWORD(wParam)&nbsp;==&nbsp;<span class="cpp__number">4</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;page&nbsp;=&nbsp;(page&nbsp;&#43;&nbsp;<span class="cpp__number">1</span>)&nbsp;%&nbsp;maxPages;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClearWave(hwnd,&nbsp;buttonsY);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawWave(hwnd,&nbsp;buttonsY);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>&nbsp;(LOWORD(wParam)&nbsp;==&nbsp;<span class="cpp__number">5</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;page&nbsp;=&nbsp;(page&nbsp;-&nbsp;<span class="cpp__number">1</span>)&nbsp;%&nbsp;maxPages;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(page&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;page&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClearWave(hwnd,&nbsp;buttonsY);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawWave(hwnd,&nbsp;buttonsY);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_CREATE:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*&nbsp;create&nbsp;buttons&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;cxChar,&nbsp;cyChar,&nbsp;height,&nbsp;x,&nbsp;y;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HDC</span>&nbsp;hDC&nbsp;=&nbsp;GetDC(hwnd);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RECT&nbsp;crect;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TEXTMETRIC&nbsp;textMetric;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GetTextMetrics(hDC,&nbsp;&amp;textMetric);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GetClientRect(hwnd,&nbsp;&amp;crect);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cxChar&nbsp;=&nbsp;textMetric.tmAveCharWidth;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cyChar&nbsp;=&nbsp;textMetric.tmHeight&nbsp;&#43;&nbsp;textMetric.tmExternalLeading;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;height&nbsp;=&nbsp;<span class="cpp__number">8</span>&nbsp;*&nbsp;cyChar&nbsp;/&nbsp;<span class="cpp__number">4</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x&nbsp;=&nbsp;cxChar;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;y&nbsp;=&nbsp;cyChar;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonsY&nbsp;=&nbsp;<span class="cpp__number">4</span>&nbsp;*&nbsp;cyChar&nbsp;&#43;&nbsp;height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;NUMBERBUTTONS;&nbsp;i&#43;&#43;)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;width&nbsp;=&nbsp;<span class="cpp__number">20</span>&nbsp;*&nbsp;cxChar;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hwndButton[i]&nbsp;=&nbsp;CreateWindow(<span class="cpp__string">&quot;button&quot;</span>,&nbsp;button[i].text,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WS_CHILD&nbsp;|&nbsp;WS_VISIBLE&nbsp;|&nbsp;button[i].style,&nbsp;x,&nbsp;y,&nbsp;width,&nbsp;height,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hwnd,&nbsp;(<span class="cpp__datatype">HMENU</span>)i,&nbsp;((LPCREATESTRUCT)lParam)-&gt;hInstance,&nbsp;NULL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x&nbsp;&#43;=&nbsp;width&nbsp;&#43;&nbsp;<span class="cpp__number">4</span>&nbsp;*&nbsp;cxChar;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveformat.cbSize&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveformat.nAvgBytesPerSec&nbsp;=&nbsp;<span class="cpp__number">44100</span>&nbsp;*&nbsp;<span class="cpp__number">2</span>&nbsp;*&nbsp;<span class="cpp__number">16</span>&nbsp;/&nbsp;<span class="cpp__number">8</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveformat.nBlockAlign&nbsp;=&nbsp;<span class="cpp__number">4</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveformat.nChannels&nbsp;=&nbsp;<span class="cpp__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveformat.nSamplesPerSec&nbsp;=&nbsp;<span class="cpp__number">44100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveformat.wBitsPerSample&nbsp;=&nbsp;<span class="cpp__number">16</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveformat.wFormatTag&nbsp;=&nbsp;WAVE_FORMAT_PCM;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_DESTROY:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(playing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveOutClose(waveOut);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(recording)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveInStop(waveIn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveInClose(waveIn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PostQuitMessage(<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WIM_CLOSE:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(recording)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnterCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;recording&nbsp;=&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stopped&nbsp;=&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WriteAudioCDRIFFFile();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LeaveCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WIM_DATA:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(recording)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnterCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;waveHeader.dwBytesRecorded;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;audioCaptureBuffer[audioLength&nbsp;&#43;&nbsp;i]&nbsp;=&nbsp;waveHeader.lpData[i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;audioLength&nbsp;=&nbsp;(audioLength&nbsp;&#43;&nbsp;waveHeader.dwBytesRecorded)&nbsp;%&nbsp;acbSize;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveInAddBuffer(waveIn,&nbsp;&amp;waveHeader,&nbsp;<span class="cpp__keyword">sizeof</span>(waveHeader));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LeaveCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WIM_OPEN:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(recdSelected)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnterCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bzero(&amp;waveHeader,&nbsp;<span class="cpp__keyword">sizeof</span>(waveHeader))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(waveInPrepareHeader(waveIn,&nbsp;&amp;waveHeader,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">sizeof</span>(waveHeader))&nbsp;!=&nbsp;MMSYSERR_NOERROR)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hWnd,&nbsp;<span class="cpp__string">&quot;could&nbsp;not&nbsp;prepare&nbsp;wave&nbsp;header&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__string">&quot;Warning&nbsp;Message&quot;</span>,&nbsp;MB_ICONWARNING&nbsp;|&nbsp;MB_OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveInClose(waveIn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveHeader.dwBufferLength&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(waveHdrBuffer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveHeader.lpData&nbsp;=&nbsp;waveHdrBuffer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bzero(&amp;waveHdrBuffer,&nbsp;<span class="cpp__keyword">sizeof</span>(waveHdrBuffer))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LeaveCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(waveInStart(waveIn)&nbsp;!=&nbsp;MMSYSERR_NOERROR)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hWnd,&nbsp;<span class="cpp__string">&quot;could&nbsp;not&nbsp;start&nbsp;input&nbsp;device&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__string">&quot;Warning&nbsp;Message&quot;</span>,&nbsp;MB_ICONWARNING&nbsp;|&nbsp;MB_OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveInClose(waveIn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnterCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;((error&nbsp;=&nbsp;waveInAddBuffer(waveIn,&nbsp;&amp;waveHeader,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">sizeof</span>(waveHeader)))&nbsp;!=&nbsp;MMSYSERR_NOERROR)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hWnd,&nbsp;<span class="cpp__string">&quot;could&nbsp;not&nbsp;add&nbsp;buffer&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__string">&quot;Warning&nbsp;Message&quot;</span>,&nbsp;MB_ICONWARNING&nbsp;|&nbsp;MB_OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveInClose(waveIn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LeaveCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;recording&nbsp;=&nbsp;TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stopped&nbsp;=&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WOM_CLOSE:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(playing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnterCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;playing&nbsp;=&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stopped&nbsp;=&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stopped&nbsp;=&nbsp;TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveOutClose(waveOut);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(hwndButton[<span class="cpp__number">0</span>],&nbsp;TRUE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(hwndButton[<span class="cpp__number">2</span>],&nbsp;TRUE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;playSelected&nbsp;=&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetWindowText((<span class="cpp__datatype">HWND</span>)lParam,&nbsp;<span class="cpp__string">&quot;Start&nbsp;Playing&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LeaveCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WOM_DONE:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(playing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnterCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(audioPtr&nbsp;&#43;&nbsp;<span class="cpp__keyword">sizeof</span>(waveHdrBuffer)&nbsp;&lt;&nbsp;audioLength)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;playLength&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(waveHdrBuffer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;playLength&nbsp;=&nbsp;audioLength&nbsp;%&nbsp;<span class="cpp__keyword">sizeof</span>(waveHdrBuffer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;playLength;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveHeader.lpData[i]&nbsp;=&nbsp;audioCaptureBuffer[audioPtr&nbsp;&#43;&nbsp;i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveHeader.dwBufferLength&nbsp;=&nbsp;playLength;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveOutWrite(waveOut,&nbsp;&amp;waveHeader,&nbsp;<span class="cpp__keyword">sizeof</span>(waveHeader));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;audioPtr&nbsp;&#43;=&nbsp;playLength;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LeaveCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WOM_OPEN:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(playSelected)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;((error&nbsp;=&nbsp;ReadAudioCDRIFFFile())&nbsp;!=&nbsp;NoError)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hWnd,&nbsp;<span class="cpp__string">&quot;could&nbsp;not&nbsp;read&nbsp;RIFF&nbsp;Wave&nbsp;File&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__string">&quot;Error&nbsp;Message&quot;</span>,&nbsp;MB_ICONSTOP&nbsp;|&nbsp;MB_OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;close(handle);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;exit(<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnterCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(waveOutPrepareHeader(waveOut,&nbsp;&amp;waveHeader,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">sizeof</span>(waveHeader))&nbsp;!=&nbsp;MMSYSERR_NOERROR)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hWnd,&nbsp;<span class="cpp__string">&quot;could&nbsp;not&nbsp;prepare&nbsp;wave&nbsp;header&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__string">&quot;Warning&nbsp;Message&quot;</span>,&nbsp;MB_ICONWARNING&nbsp;|&nbsp;MB_OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveOutClose(waveOut);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveHeader.lpData&nbsp;=&nbsp;waveHdrBuffer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(audioPtr&nbsp;&#43;&nbsp;<span class="cpp__keyword">sizeof</span>(waveHdrBuffer)&nbsp;&lt;&nbsp;audioLength)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;playLength&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(waveHdrBuffer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;playLength&nbsp;=&nbsp;audioLength&nbsp;%&nbsp;<span class="cpp__keyword">sizeof</span>(waveHdrBuffer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;playLength;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveHeader.lpData[i]&nbsp;=&nbsp;audioCaptureBuffer[audioPtr&nbsp;&#43;&nbsp;i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveHeader.dwBufferLength&nbsp;=&nbsp;playLength;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;((error&nbsp;=&nbsp;waveOutWrite(waveOut,&nbsp;&amp;waveHeader,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">sizeof</span>(waveHeader)))&nbsp;!=&nbsp;MMSYSERR_NOERROR)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hWnd,&nbsp;<span class="cpp__string">&quot;could&nbsp;not&nbsp;add&nbsp;buffer&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__string">&quot;Warning&nbsp;Message&quot;</span>,&nbsp;MB_ICONWARNING&nbsp;|&nbsp;MB_OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waveOutClose(waveOut);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;audioPtr&nbsp;&#43;=&nbsp;playLength;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LeaveCriticalSection(&amp;cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;playing&nbsp;=&nbsp;TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stopped&nbsp;=&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;DefWindowProc(hwnd,&nbsp;iMsg,&nbsp;wParam,&nbsp;lParam);&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">int</span>&nbsp;WINAPI&nbsp;WinMain(<span class="cpp__datatype">HINSTANCE</span>&nbsp;hInstance,&nbsp;<span class="cpp__datatype">HINSTANCE</span>&nbsp;hPrevInstance,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">PSTR</span>&nbsp;szCmdLine,&nbsp;<span class="cpp__datatype">int</span>&nbsp;iCmdShow)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__datatype">char</span>&nbsp;szAppName[]&nbsp;=&nbsp;<span class="cpp__string">&quot;Audio&nbsp;Capture&nbsp;And&nbsp;Playing&nbsp;RIFF&nbsp;Wave&nbsp;File&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__datatype">char</span>&nbsp;title[]&nbsp;=&nbsp;<span class="cpp__string">&quot;Win32&nbsp;Audio&nbsp;Capture&nbsp;Etc.&nbsp;by&nbsp;James&nbsp;Pate&nbsp;Williams,&nbsp;Jr.&nbsp;(c)&nbsp;2016&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MSG&nbsp;msg;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WNDCLASSEX&nbsp;&nbsp;wndclass;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wndclass.cbSize&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>&nbsp;(wndclass);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wndclass.style&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;CS_HREDRAW&nbsp;|&nbsp;CS_VREDRAW;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wndclass.lpfnWndProc&nbsp;&nbsp;&nbsp;=&nbsp;WndProc;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wndclass.cbClsExtra&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wndclass.cbWndExtra&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wndclass.hInstance&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;hInstance;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wndclass.hIcon&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wndclass.hCursor&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;LoadCursor&nbsp;(NULL,&nbsp;IDC_ARROW);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wndclass.hbrBackground&nbsp;=&nbsp;(<span class="cpp__datatype">HBRUSH</span>)&nbsp;GetStockObject(WHITE_BRUSH);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wndclass.lpszMenuName&nbsp;&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wndclass.lpszClassName&nbsp;=&nbsp;szAppName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wndclass.hIconSm&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RegisterClassEx&nbsp;(&amp;wndclass);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hWnd&nbsp;=&nbsp;CreateWindow(szAppName,&nbsp;title,&nbsp;WS_OVERLAPPEDWINDOW,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CW_USEDEFAULT,&nbsp;CW_USEDEFAULT,&nbsp;UW_WIDTH,&nbsp;UW_HEIGHT,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NULL,&nbsp;NULL,&nbsp;hInstance,&nbsp;NULL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hInst&nbsp;=&nbsp;hInstance;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ShowWindow(hWnd,&nbsp;iCmdShow);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UpdateWindow(hWnd)&nbsp;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">while</span>&nbsp;(GetMessage(&amp;msg,&nbsp;NULL,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>))&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TranslateMessage(&amp;msg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DispatchMessage(&amp;msg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;msg.wParam;&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>AudioCaptureToRIFFWaveFile.c - the main and only C source code file of the application.</em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on the Winmm.lib and this Winmm.dll, see the web and the voluminous amount of Microsoft Win32 documentation. This ancient library has been largely&nbsp;supplanted in modern universal apps.</em></p>
