// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Compute.Models
{
    public partial class VirtualMachineScaleSetOSProfile : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (ComputerNamePrefix != null)
            {
                writer.WritePropertyName("computerNamePrefix");
                writer.WriteStringValue(ComputerNamePrefix);
            }
            if (AdminUsername != null)
            {
                writer.WritePropertyName("adminUsername");
                writer.WriteStringValue(AdminUsername);
            }
            if (AdminPassword != null)
            {
                writer.WritePropertyName("adminPassword");
                writer.WriteStringValue(AdminPassword);
            }
            if (CustomData != null)
            {
                writer.WritePropertyName("customData");
                writer.WriteStringValue(CustomData);
            }
            if (WindowsConfiguration != null)
            {
                writer.WritePropertyName("windowsConfiguration");
                writer.WriteObjectValue(WindowsConfiguration);
            }
            if (LinuxConfiguration != null)
            {
                writer.WritePropertyName("linuxConfiguration");
                writer.WriteObjectValue(LinuxConfiguration);
            }
            if (Secrets != null)
            {
                writer.WritePropertyName("secrets");
                writer.WriteStartArray();
                foreach (var item in Secrets)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static VirtualMachineScaleSetOSProfile DeserializeVirtualMachineScaleSetOSProfile(JsonElement element)
        {
            string computerNamePrefix = default;
            string adminUsername = default;
            string adminPassword = default;
            string customData = default;
            WindowsConfiguration windowsConfiguration = default;
            LinuxConfiguration linuxConfiguration = default;
            IList<VaultSecretGroup> secrets = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("computerNamePrefix"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    computerNamePrefix = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("adminUsername"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    adminUsername = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("adminPassword"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    adminPassword = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customData"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    customData = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("windowsConfiguration"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    windowsConfiguration = WindowsConfiguration.DeserializeWindowsConfiguration(property.Value);
                    continue;
                }
                if (property.NameEquals("linuxConfiguration"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    linuxConfiguration = LinuxConfiguration.DeserializeLinuxConfiguration(property.Value);
                    continue;
                }
                if (property.NameEquals("secrets"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VaultSecretGroup> array = new List<VaultSecretGroup>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(VaultSecretGroup.DeserializeVaultSecretGroup(item));
                        }
                    }
                    secrets = array;
                    continue;
                }
            }
            return new VirtualMachineScaleSetOSProfile(computerNamePrefix, adminUsername, adminPassword, customData, windowsConfiguration, linuxConfiguration, secrets);
        }
    }
}
