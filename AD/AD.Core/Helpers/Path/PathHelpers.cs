﻿namespace AD.Core
{
    using System.IO;

    /// <summary>
    /// A helper class thet contains functions for dealing with phisycal files on disk.
    /// </summary>
    public static class PathHelpers
    {
        #region public methods

        /// <summary>
        /// Gets the name of the file from provided full path.
        /// </summary>
        /// <param name="fullPath">The full path to the item.</param>
        /// <returns></returns>
        public static string GetFileName(string fullPath)
        {
            // If path is not valid return empty string.
            if (string.IsNullOrEmpty(fullPath))
                return string.Empty;

            var lastIndex = fullPath.LastIndexOf('\\');

            if (lastIndex <= 0)
                return fullPath;

            // Return file name without extension.
            return Path.GetFileNameWithoutExtension(fullPath.Substring(lastIndex + 1));
        }

        #endregion
    }
}
