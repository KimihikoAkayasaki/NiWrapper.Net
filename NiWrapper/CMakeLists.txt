cmake_minimum_required(VERSION 3.12)

project(NiWrapper)

file(GLOB NIWRAPPER_HDR "include/*.h")
file(GLOB NIWRAPPER_SRC "src/*.cpp")

# ----------------------- OpenNI -------------------------------
set(OPENNI_ROOT "${CMAKE_CURRENT_LIST_DIR}/../vendor/OpenNI")
set(OPENNI_INCLUDE_DIR "${OPENNI_ROOT}/Include")

link_directories("${OPENNI_ROOT}/Lib")
link_directories("${OPENNI_ROOT}/Redist")
# --------------------------------------------------------------

add_library(NiWrapper SHARED ${NIWRAPPER_SRC} ${NIWRAPPER_HDR})

target_include_directories(NiWrapper PRIVATE "${OPENNI_INCLUDE_DIR}")
target_include_directories(NiWrapper PRIVATE "${CMAKE_CURRENT_SOURCE_DIR}/include")

target_link_libraries(NiWrapper PRIVATE OpenNI2)
