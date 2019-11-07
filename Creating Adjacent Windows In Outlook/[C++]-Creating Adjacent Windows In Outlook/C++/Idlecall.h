// idlecall.h : Global declaration of idle call helpers
#pragma once

enum IdleTaskId
{
	idleFindTopLevelWindows = 1,
};


const UINT c_uiIdleDefault = 50; // millisecs

// Initialization functions
void InitializeIdle();
void UninitializeIdle();

// Add or remove an idle function
void CallIdle(IdleTaskId iIdleCall, UINT uElapse = c_uiIdleDefault);
void RemoveIdle(int iIdleCall);
