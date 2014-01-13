﻿/*
    Copyright (C) 2013 Soroush Falahati - soroush@falahati.net

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
	*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenNIWrapper
{
    public class CoordinateConverter
    {
        [DllImport("NiWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern OpenNI.Status CoordinateConverter_convertDepthToColor(
            IntPtr depthStream, IntPtr colorStream, int depthX, int depthY, UInt16 depthZ,
            ref int pColorX, ref int pColorY);
        public static OpenNI.Status ConvertDepthToColor(VideoStream depthStream, VideoStream colorStream,
            int depthX, int depthY, UInt16 depthZ, out int pColorX, out int pColorY)
        {
            pColorX = 0;
            pColorY = 0;
            return CoordinateConverter_convertDepthToColor(depthStream.Handle, colorStream.Handle,
                    depthX, depthY, depthZ,ref pColorX, ref pColorY);
        }

        [DllImport("NiWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern OpenNI.Status CoordinateConverter_convertDepthToWorld(
            IntPtr depthStream, int depthX, int depthY, UInt16 depthZ,
            ref float pWorldX, ref float pWorldY, ref float pWorldZ);
        [DllImport("NiWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern OpenNI.Status CoordinateConverter_convertDepthToWorld_Float(
            IntPtr depthStream, float depthX, float depthY, float depthZ,
            ref float pWorldX, ref float pWorldY, ref float pWorldZ);
        public static OpenNI.Status convertDepthToWorld(VideoStream depthStream,
            int depthX, int depthY, UInt16 depthZ, out float pWorldX, out float pWorldY, out float pWorldZ)
        {
            pWorldX = 0;
            pWorldY = 0;
            pWorldZ = 0;
            return CoordinateConverter_convertDepthToWorld(depthStream.Handle,
                    depthX, depthY, depthZ, ref pWorldX, ref pWorldY, ref pWorldZ);
        }
        public static OpenNI.Status ConvertDepthToWorld(VideoStream depthStream,
            float depthX, float depthY, float depthZ, out float pWorldX, out float pWorldY, out float pWorldZ)
        {
            pWorldX = 0;
            pWorldY = 0;
            pWorldZ = 0;
            return CoordinateConverter_convertDepthToWorld_Float(depthStream.Handle,
                    depthX, depthY, depthZ, ref pWorldX, ref pWorldY, ref pWorldZ);
        }

        [DllImport("NiWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern OpenNI.Status CoordinateConverter_convertWorldToDepth(
            IntPtr depthStream, float worldX, float worldY, float worldZ,
            ref int pDepthX, ref int pDepthY, ref UInt16 pDepthZ);
        [DllImport("NiWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern OpenNI.Status CoordinateConverter_convertWorldToDepth_Float(
            IntPtr depthStream, float worldX, float worldY, float worldZ,
            ref float pDepthX, ref float pDepthY, ref float pDepthZ);
        public static OpenNI.Status ConvertWorldToDepth(
            VideoStream depthStream, float worldX, float worldY, float worldZ,
            out int pDepthX, out int pDepthY, out UInt16 pDepthZ)
        {
            pDepthX = 0;
            pDepthY = 0;
            pDepthZ = 0;
            return CoordinateConverter_convertWorldToDepth(depthStream.Handle,
                worldX, worldY, worldZ, ref pDepthX, ref pDepthY, ref pDepthZ);
        }
        public static OpenNI.Status ConvertWorldToDepth(
            VideoStream depthStream, float worldX, float worldY, float worldZ,
            out float pDepthX, out float pDepthY, out float pDepthZ)
        {
            pDepthX = 0;
            pDepthY = 0;
            pDepthZ = 0;
            return CoordinateConverter_convertWorldToDepth_Float(depthStream.Handle,
                worldX, worldY, worldZ, ref pDepthX, ref pDepthY, ref pDepthZ);
        }
    }
}
