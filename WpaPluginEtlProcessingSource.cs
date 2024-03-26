﻿using Microsoft.Performance.SDK.Processing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpa_plugin_etl
{
    [ProcessingSource(
        "{3ABDFE57-0E4F-4223-A7F4-3F6F5813D741}",  // The GUID must be unique for your Processing Source. You can use Visual Studio's Tools -> Create Guid… tool to create a new GUID
        "WindowsPerf WPA Plugin ETL",    
        "WindowsPerf Driver ETW Reader")]
    [FileDataSource(
        ".etl",                          
        "ETL files")]
    public class WpaPluginEtlProcessingSource : ProcessingSource
    {
        private IApplicationEnvironment applicationEnvironment;

        public override ProcessingSourceInfo GetAboutInfo()
        {
            return new ProcessingSourceInfo
            {
                CopyrightNotice = "Copyright 2024 Linaro",

                LicenseInfo = new LicenseInfo
                {
                    Name = "XXX",
                    Text = "Please see the link for the full license text.",
                    Uri = "https://a.b.com/LICENSE.txt",
                },

                Owners = new[]
                {
                    new ContactInfo
                    {
                        Address = "XXX",
                        EmailAddresses = new[]
                        {
                            "X@X.com",
                        },
                    },
                },

                ProjectInfo = new ProjectInfo
                {
                    Uri = "https://a.b.com",
                },

                AdditionalInformation = new[]
                {
                    "XXX.",
                }
            };
        }

        protected override void SetApplicationEnvironmentCore(IApplicationEnvironment applicationEnvironment)
        {
            this.applicationEnvironment = applicationEnvironment;
        }

        protected override ICustomDataProcessor CreateProcessorCore(
            IEnumerable<IDataSource> dataSources,
            IProcessorEnvironment processorEnvironment,
            ProcessorOptions options)
        {
            return new WpaPluginEtlDataProcessor(
                dataSources.Select(x => x.Uri.LocalPath).ToArray(),
                options,
                this.applicationEnvironment,
                processorEnvironment);
        }

        protected override bool IsDataSourceSupportedCore(IDataSource source)
        {
            Debug.WriteLine("yadayada");
            return true;
        }
    }
}
