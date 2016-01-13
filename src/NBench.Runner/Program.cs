﻿// Copyright (c) Petabridge <https://petabridge.com/>. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using NBench.Reporting;
using NBench.Reporting.Targets;
using NBench.Sdk.Compiler;
using NBench.Sdk;

namespace NBench.Runner
{
    class Program
    {  
        /// <summary>
        /// NBench Runner takes the following <see cref="args"/>
        /// 
        /// C:\> NBench.Runner.exe [assembly name] [output-directory={dir-path}]
        /// 
        /// </summary>
        /// <param name="args">The commandline arguments</param>
        static int Main(string[] args)
        { 
            TestPackage package = new TestPackage(CommandLine.GetFiles());
            package.ConfigurationFile = CommandLine.GetProperty("configuration");
            package.OutputDirectory = CommandLine.GetProperty("output-directory");
            package.Validate();

            bool anyAssertFailures = TestRunner.Run(package);
       
            return anyAssertFailures ? -1 : 0;
        }
    }
}

