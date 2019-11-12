#include <iostream>
#include <vector>
#include <cuda_runtime.h>

#pragma comment(lib, "cudart")

using std::cerr;
using std::cout;
using std::endl;
using std::exception;
using std::vector;

static const int MaxSize = 96;

// CUDA kernel: cubes each array value
__global__ void cubeKernel(float* result, float* data)
{
	int idx = threadIdx.x;
	float f = data[idx];
	result[idx] = f * f * f;
}

// Initializes data on the host
void InitializeData(vector<float>& data)
{
	for (int i = 0; i < MaxSize; ++i)
	{
		data[i] = static_cast<float>(i);
	}
}

// Executes CUDA kernel
void RunCubeKernel(vector<float>& data, vector<float>& result)
{
	const size_t size = MaxSize * sizeof(float);

	// TODO: test for error
	float* d;
	float* r;
	cudaError hr;

	hr = cudaMalloc(reinterpret_cast<void**>(&d), size);			// Could return 46 if device is unavailable.
	if (hr == cudaErrorDevicesUnavailable)
	{
		cerr << "Close all browsers and rerun" << endl;
		throw std::runtime_error("Close all browsers and rerun");
	}

	hr = cudaMalloc(reinterpret_cast<void**>(&r), size);
	if (hr == cudaErrorDevicesUnavailable)
	{
		cerr << "Close all browsers and rerun" << endl;
		throw std::runtime_error("Close all browsers and rerun");
	}

	// Copy data to the device
	cudaMemcpy(d, &data[0], size, cudaMemcpyHostToDevice);

	// Launch kernel: 1 block, 96 threads
	// Important: Do not exceed number of threads returned by the device query, 1024 on my computer.
	cubeKernel<<<1, MaxSize>>>(r, d);

	// Copy back to the host
	cudaMemcpy(&result[0], r, size, cudaMemcpyDeviceToHost);

	// Free device memory
	cudaFree(d);
	cudaFree(r);
}

// Main entry into the program
int main(void)
{
	cout << "In main." << endl;

	// Create sample data
	vector<float> data(MaxSize);
	InitializeData(data);

	// Compute cube on the device
	vector<float> cube(MaxSize);
	RunCubeKernel(data, cube);

	// Print out results
	cout << "Cube kernel results." << endl << endl;

	for (int i = 0; i < MaxSize; ++i)
	{
		cout << data[i] << "^ = " << cube[i] << endl;
	}

	return 0;
}
