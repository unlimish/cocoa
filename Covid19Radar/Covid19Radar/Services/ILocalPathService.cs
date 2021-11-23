﻿/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.IO;
using Xamarin.Essentials;

namespace Covid19Radar.Services
{
    public interface ILocalPathService
    {
        private const string EXPOSURE_CONFIGURATION_DIR = "exposure_configuration";
        private const string CURRENT_EXPOSURE_CONFIGURATION_FILENAME = "current.json";

        string ExposureConfigurationDirPath =>
            Path.Combine(FileSystem.AppDataDirectory, EXPOSURE_CONFIGURATION_DIR);

        string CurrentExposureConfigurationPath =>
            Path.Combine(ExposureConfigurationDirPath, CURRENT_EXPOSURE_CONFIGURATION_FILENAME);

        string LogsDirPath { get; }
        string LogUploadingTmpPath { get; }
        string LogUploadingPublicPath { get; }
    }
}
