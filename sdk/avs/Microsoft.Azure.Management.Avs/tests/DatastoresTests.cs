// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Avs;
using Microsoft.Azure.Management.Avs.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Avs.Tests
{
    public class DatastoresTests : TestBase
    {
        const string PREFIX = "avs-sdk-ds-";

        [Fact]
        public void DatastoresAll()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = TestUtilities.GenerateName(PREFIX + "rg");
            string cloudName = TestUtilities.GenerateName(PREFIX + "cloud");
            string clusterName = TestUtilities.GenerateName(PREFIX + "cluster");

            using var avsClient = context.GetServiceClient<AvsClient>();

            var datastoreName = "datastore1";
            var datastore = avsClient.Datastores.CreateOrUpdate(rgName, cloudName, clusterName, datastoreName, new Datastore {
                NetAppVolume = new NetAppVolume {
                    Id = "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/ResourceGroup1/providers/Microsoft.NetApp/netAppAccounts/NetAppAccount1/capacityPools/CapacityPool1/volumes/NFSVol1"
                }
            });

            avsClient.Datastores.List(rgName, cloudName, clusterName);

            avsClient.Datastores.Get(rgName, cloudName, clusterName, datastoreName);

            avsClient.Datastores.Delete(rgName, cloudName, clusterName, datastoreName);
        }
    }
}