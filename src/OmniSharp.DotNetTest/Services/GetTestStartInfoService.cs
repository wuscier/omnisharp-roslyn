using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
using OmniSharp.DotNetTest.Models;
using OmniSharp.Mef;
using OmniSharp.Services;

namespace OmniSharp.DotNetTest.Services
{
    [OmniSharpHandler(OmnisharpEndpoints.V2.GetTestStartInfo, LanguageNames.CSharp)]
    public class GetTestStartInfoService : BaseTestService<GetTestStartInfoRequest, GetTestStartInfoResponse>
    {
        [ImportingConstructor]
        public GetTestStartInfoService(OmniSharpWorkspace workspace, DotNetCliService dotNetCli, IEventEmitter eventEmitter, ILoggerFactory loggerFactory)
            : base(workspace, dotNetCli, eventEmitter, loggerFactory)
        {
        }

        protected override GetTestStartInfoResponse HandleRequest(GetTestStartInfoRequest request, TestManager testManager)
        {
            return testManager.GetTestStartInfo(request.MethodName, request.TestFrameworkName);
        }
    }
}
