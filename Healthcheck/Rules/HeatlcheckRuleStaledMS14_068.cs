﻿//
// Copyright (c) Ping Castle. All rights reserved.
// https://www.pingcastle.com
//
// Licensed under the Non-Profit OSL. See LICENSE file in the project root for full license information.
//
using System;
using System.Collections.Generic;
using System.Text;

namespace PingCastle.Healthcheck.Rules
{
	[HeatlcheckRuleModel("S-Vuln-MS14-068", HealthcheckRiskRuleCategory.StaleObjects, HealthcheckRiskModelCategory.VulnerabilityManagement)]
	[HeatlcheckRuleComputation(RuleComputationType.TriggerOnPresence, 100)]
    public class HeatlcheckRuleStaledMS14_068 : HeatlcheckRuleBase
    {
		protected override int? AnalyzeDataNew(HealthcheckData healthcheckData)
        {
			DateTime alertDate = new DateTime(2014, 11, 18);
			if (healthcheckData.DomainControllers != null && healthcheckData.DomainControllers.Count > 0)
			{
				foreach (var DC in healthcheckData.DomainControllers)
				{
					if (DC.StartupTime != DateTime.MinValue)
					{
						if (DC.StartupTime < alertDate)
						{
							AddRawDetail(DC.DCName,"StartupTime=" + DC.StartupTime);
						}
					}
				}
			}
			return null;
        }
    }
}
