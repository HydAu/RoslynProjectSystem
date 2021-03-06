﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.ComponentModel.Composition;

namespace Microsoft.VisualStudio.ProjectSystem
{
    /// <summary>
    ///     Provides a default implementation of <see cref="IUnconfiguredProjectCommonServices"/>.
    /// </summary>
    [Export(typeof(IUnconfiguredProjectCommonServices))]
    internal class UnconfiguredProjectCommonServices : IUnconfiguredProjectCommonServices
    {
        private readonly Lazy<IProjectThreadingService> _threadingService;
        private readonly ActiveConfiguredProject<ConfiguredProject> _activeConfiguredProject;
        private readonly ActiveConfiguredProject<ProjectProperties> _activeConfiguredProjectProperties;

        [ImportingConstructor]
        public UnconfiguredProjectCommonServices(Lazy<IProjectThreadingService> threadingService, ActiveConfiguredProject<ConfiguredProject> activeConfiguredProject, ActiveConfiguredProject<ProjectProperties> activeConfiguredProjectProperties)
        {
            Requires.NotNull(threadingService, nameof(threadingService));
            Requires.NotNull(activeConfiguredProject, nameof(activeConfiguredProject));
            Requires.NotNull(activeConfiguredProjectProperties, nameof(activeConfiguredProjectProperties));

            _threadingService = threadingService;
            _activeConfiguredProject = activeConfiguredProject;
            _activeConfiguredProjectProperties = activeConfiguredProjectProperties;
        }

        public IProjectThreadingService ThreadingService
        {
            get { return _threadingService.Value; }
        }

        public ConfiguredProject ActiveConfiguredProject
        {
            get { return _activeConfiguredProject.Value; }
        }

        public ProjectProperties ActiveConfiguredProjectProperties
        {
            get { return _activeConfiguredProjectProperties.Value; }
        }
    }
}
