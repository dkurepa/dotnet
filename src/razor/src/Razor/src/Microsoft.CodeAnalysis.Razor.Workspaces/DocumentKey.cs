﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

#nullable disable

using System;
using Microsoft.Extensions.Internal;

namespace Microsoft.CodeAnalysis.Razor;

public readonly struct DocumentKey : IEquatable<DocumentKey>
{
    public DocumentKey(string projectFilePath, string documentFilePath)
    {
        ProjectFilePath = projectFilePath;
        DocumentFilePath = documentFilePath;
    }

    public string ProjectFilePath { get; }

    public string DocumentFilePath { get; }

    public bool Equals(DocumentKey other)
    {
        return
            FilePathComparer.Instance.Equals(ProjectFilePath, other.ProjectFilePath) &&
            FilePathComparer.Instance.Equals(DocumentFilePath, other.DocumentFilePath);
    }

    public override bool Equals(object obj)
    {
        return obj is DocumentKey key && Equals(key);
    }

    public override int GetHashCode()
    {
        var hash = new HashCodeCombiner();
        hash.Add(ProjectFilePath, FilePathComparer.Instance);
        hash.Add(DocumentFilePath, FilePathComparer.Instance);
        return hash;
    }
}
