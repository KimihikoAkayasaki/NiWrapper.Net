#ifndef NITE_WRAPPER_DEFINES_H
#define NITE_WRAPPER_DEFINES_H

#if defined(_MSC_VER) || defined(__MINGW32__)
    #define NITE_WRAPPER_API NITE_WRAPPER_API
#else
    #define NITE_WRAPPER_API
#endif

#endif /* NITE_WRAPPER_DEFINES_H */
