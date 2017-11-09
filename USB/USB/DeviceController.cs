﻿using MediaDevices;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UsbEject;
namespace USB
{
    public class DeviceController
    {
        public List<Device> Devices;

        public DeviceController()
        {
            Devices = new List<Device>();
        }

        public List<Device> GetDevices()
        {
            Devices.Clear();
            foreach (var device in MediaDevice.GetDevices())
            {
                device.Connect();
                IEnumerable<MediaDirectoryInfo> rootDirectory = device.GetRootDirectory().EnumerateDirectories();
                Devices.Add(new Device
                {
                    Name = device.FriendlyName,
                    DeviceType = device.DeviceType
                });
                var volumes = device.DeviceType == DeviceType.Generic ? GetGenericVolumes(rootDirectory,Devices.Last()) : GetMtpVolumes(rootDirectory);
                Devices.Last().Volumes = volumes;
                device.Disconnect();
            }
            return Devices;
        }

        private List<Volume> GetGenericVolumes(IEnumerable<MediaDirectoryInfo> rootDirectory, Device device)
        {
            List<Volume> volumes = new List<Volume>();
            foreach (var volume in rootDirectory)
            {
                DriveInfo driveInfo = new DriveInfo(volume.Name);
                device.Name += " ("+ volume.Name+")";
                volumes.Add(new Volume()
                {
                    Name = volume.Name,
                    Total = driveInfo.TotalSize,
                    Free = driveInfo.TotalFreeSpace,
                    Used = driveInfo.TotalSize - driveInfo.TotalFreeSpace
                });
            }
            return volumes;
        }

        private List<Volume> GetMtpVolumes(IEnumerable<MediaDirectoryInfo> rooDirectory)
        {
            List<Volume> volumes = new List<Volume>();
            foreach (var volume in rooDirectory)
            {
                volumes.Add(new Volume()
                {
                    Name = volume.Name
                });
            }
            return volumes;
        }

        public void EjectDevice(Device device)
        {
            var dev = new VolumeDeviceClass().SingleOrDefault(v => v.LogicalDrive == device.Volumes.First().Name);
            dev?.Eject(false);
        }
    }
}