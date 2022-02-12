using System;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using Opsi.Architecture;
using Opsi.Cloud.Core.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opsi.Cloud.Core.Model;
using RefactorMe;
using RefactorMe.Factory;

namespace Opsi.Cloud.Core
{
    public class ExternalIdGeneratorService : IExternalIdGeneratorService
    {
        private readonly ILogger<ExternalIdGeneratorService> _logger;

        private const char SectionStartChar = '{';
        private const string ExternalIdKeyValue = "externalId";

        public ExternalIdGeneratorService(ILogger<ExternalIdGeneratorService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="typeMetadata"></param>
        /// <returns></returns>
        public async Task<ServiceActionResult> GenerateAsync(
            List<Dictionary<string, object>> entities,
            TypeMetadata typeMetadata)
        {
            var result = new ServiceActionResult();

            try
            {
                var namingPattern = GetNamingPattern(typeMetadata.Name);

                if (namingPattern == string.Empty)
                {
                    return result;
                }

                foreach (var entity in entities)
                {
                    var sb = new StringBuilder();

                    foreach (var section in GetSections(namingPattern))
                    {
                        if (section.StartsWith(SectionStartChar))
                        {
                            var args = GetArguments(section);

                            var strategy = ExternalIdFactory.CreateExternalIdStrategy(args[0], args[1], entity);

                            sb.Append(await strategy.GetExternalIdAsync());
                        }
                        else
                        {
                            sb.Append(section);
                        }
                    }

                    entity[ExternalIdKeyValue] = sb.ToString();
                }

                result.Value = entities;
            }
            catch (Exception e)
            {
                result.AddError(e.Message);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetNamingPattern(string name)
        {
            return NamingPattern.NamingPatterns
                .TryGetValue(name, out var namingPattern) ? namingPattern : string.Empty;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="namingPattern"></param>
        /// <returns></returns>
        private static IEnumerable<string> GetSections(string namingPattern)
        {
            return Regex.Split(namingPattern, RegExConstants.NamingPatternRegexMatch)
                .Where(s => s != string.Empty)
                .ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        private static string[] GetArguments(string section)
        {
            return  Regex.Split(section, RegExConstants.SectionRegexMatch)
                .Where(s => s != string.Empty)
                .ToArray();
        }
    }
}