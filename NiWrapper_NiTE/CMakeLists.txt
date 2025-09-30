cmake_minimum_required(VERSION 3.12)

project(NiWrapper_NiTE)

if(MSVC)
    set(CMAKE_MSVC_RUNTIME_LIBRARY
        $<$<CONFIG:Debug>:MultiThreadedDebug>      # /MTd
        $<$<CONFIG:Release>:MultiThreaded>         # /MT
        $<$<CONFIG:RelWithDebInfo>:MultiThreaded>  # /MT
        $<$<CONFIG:MinSizeRel>:MultiThreaded>      # /MT
    )
endif()

file(GLOB NIWRAPPER_HDR "include/*.h")
file(GLOB NIWRAPPER_SRC "src/*.cpp")

# ----------------------- OpenNI and NiTE ----------------------
set(OPENNI_ROOT "${CMAKE_CURRENT_LIST_DIR}/../vendor/OpenNI")
set(OPENNI_INCLUDE_DIR "${OPENNI_ROOT}/Include")

link_directories("${OPENNI_ROOT}/Lib")
link_directories("${OPENNI_ROOT}/Redist")

set(NITE_ROOT "${CMAKE_CURRENT_LIST_DIR}/../vendor/NiTE")
set(NITE_INCLUDE_DIR "${NITE_ROOT}/Include")

link_directories("${NITE_ROOT}/Lib")
link_directories("${NITE_ROOT}/Redist")
# --------------------------------------------------------------

add_library(NiWrapper_NiTE SHARED ${NIWRAPPER_SRC} ${NIWRAPPER_HDR})

target_include_directories(NiWrapper_NiTE PRIVATE "${OPENNI_INCLUDE_DIR}" "${NITE_INCLUDE_DIR}")
target_include_directories(NiWrapper_NiTE PRIVATE "${CMAKE_CURRENT_SOURCE_DIR}/include")

target_link_libraries(NiWrapper_NiTE OpenNI2 NiTE2)
