// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Avs;
using Microsoft.Azure.Management.Avs.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Avs.Tests
{
    public class ScriptingTests : TestBase
    {
        const string PREFIX = "avs-sdk-script-";

        [Fact]
        public void ScriptPackagesAll()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = TestUtilities.GenerateName(PREFIX + "rg");
            string cloudName = TestUtilities.GenerateName(PREFIX + "cloud");

            using var avsClient = context.GetServiceClient<AvsClient>();

            var scriptPackage = "JSDR.Configuration@1.0.16";
            avsClient.ScriptPackages.List(rgName, cloudName);

            avsClient.ScriptPackages.Get(rgName, cloudName, scriptPackage);

        }

        [Fact]
        public void ScriptCmdletsAll()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = TestUtilities.GenerateName(PREFIX + "rg");
            string cloudName = TestUtilities.GenerateName(PREFIX + "cloud");

            using var avsClient = context.GetServiceClient<AvsClient>();

            var scriptPackage = "JSDR.Configuration@1.0.16";
            var cmdletName = "Invoke-PreflightJetDR";
            avsClient.ScriptCmdlets.List(rgName, cloudName, scriptPackage);

            avsClient.ScriptCmdlets.Get(rgName, cloudName, scriptPackage, cmdletName);

        }

        [Fact]
        public void ScriptExecutionsAll() 
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = TestUtilities.GenerateName(PREFIX + "rg");
            string cloudName = TestUtilities.GenerateName(PREFIX + "cloud");
            string executionName = TestUtilities.GenerateName(PREFIX + "execution");

            using var avsClient = context.GetServiceClient<AvsClient>();

            var execution = avsClient.ScriptExecutions.CreateOrUpdate(rgName, cloudName, executionName, 
                new ScriptExecution {
                    Timeout = "PT1H",
                    ScriptCmdletId = "JSDR.Configuration/1.0.16/Invoke-PreflightJetDR",
                });

            avsClient.ScriptExecutions.Get(rgName, cloudName, executionName);
            
            avsClient.ScriptExecutions.List(rgName, cloudName);
            
            avsClient.ScriptExecutions.Delete(rgName, cloudName, executionName);
        }
    }
} 
