﻿/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

namespace Covid19Radar.Api.Common
{
    /// <summary>
    /// Constant values for the entire application
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Number of days not processed or deleted
        /// </summary>
        public const int OutOfDateDays = -14;
        /// <summary>
        /// Cache Timeout
        /// </summary>
        public const int CacheTimeout = 60;
        /// <summary>
        /// Active Rolling Period
        /// </summary>
        public const uint ActiveRollingPeriod = 144;

        /// <summary>
        /// Number of days relative that have infectiousness from the date of diagnosis or onset.
        /// </summary>
        public const int DaysHasInfectiousness = -3;

        /// <summary>
        /// Extra value when TemporaryExposureKey reoprtType missing.
        /// </summary>
        public const int ReportTypeMissingValue = -1;

        /// <summary>
        /// Extra value when TemporaryExposureKey daysSinceOnsetOfSymptoms missing.
        /// </summary>
        public const int DaysSinceOnsetOfSymptomsMissingValue = int.MinValue;
    }
}
