#ifndef MSSCMP_H
#define MSSCMP_H

#include <stdio.h>
#include <errno.h>
#include <stdbool.h>
#include <string.h>
#include <stdlib.h>
#include <direct.h>
#include <stdint.h>
#include <sys/stat.h>
#include <math.h>
#include "prototype.h"

#include <windows.h>

#define msscmpDataAlign 0x00001000
#define msscmpDataStart 0x0001B000

#if defined(__TINYC__)||defined(__GNUC__)
  #define DLLOPT(a) __attribute__ ((a))
#else
  #define DLLOPT(a) __declspec(a)
#endif

#ifdef MSSCMP_EXPORT
  #define DLLAPI DLLOPT(dllexport)
#else
  #define DLLAPI
#endif

#ifdef __cplusplus
extern "C"{
#endif



typedef struct _Offsets{
    uint32_t path;
    uint32_t name;
    uint32_t data;
    uint32_t info;
} Offsets;

typedef struct _Paths{
    char path[300];
    char name[300];
    char full[600];uint32_t fullLen;
} Paths;

typedef struct _Entry{
    Offsets offsets;
    Paths paths;
    uint32_t size;
    uint32_t sampleRate;
    char * data;
} Entry;

typedef struct _File{
    FILE* fp;
    uint32_t entryCount;
    uint32_t filetableOffset;
    Entry **entries;
} File;


void  __stdcall DLLAPI init();

int  __stdcall DLLAPI extractMsscmp(const char* path);
int  __stdcall DLLAPI loadMsscmp(const char* path);
int  __stdcall DLLAPI saveMsscmp(const char* path);
int  __stdcall DLLAPI replaceEntryMsscmp(char* path, char* replacePath);


#ifdef __cplusplus
}
#endif

#endif