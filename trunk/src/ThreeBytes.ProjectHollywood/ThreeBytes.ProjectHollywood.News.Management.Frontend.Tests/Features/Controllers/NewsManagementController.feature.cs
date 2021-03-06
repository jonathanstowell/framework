﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.7.1.0
//      SpecFlow Generator Version:1.7.0.0
//      Runtime Version:4.0.30319.239
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace ThreeBytes.ProjectHollywood.News.Management.Frontend.Tests.Features.Controllers
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.7.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("NewsManagementController")]
    public partial class NewsManagementControllerFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "NewsManagementController.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "NewsManagementController", "", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create News Management Controller passing null as the Validation Resolver Throws " +
            "Arguement Null Exception")]
        public virtual void CreateNewsManagementControllerPassingNullAsTheValidationResolverThrowsArguementNullException()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create News Management Controller passing null as the Validation Resolver Throws " +
                    "Arguement Null Exception", ((string[])(null)));
#line 3
this.ScenarioSetup(scenarioInfo);
#line 4
 testRunner.Given("I have a null service");
#line 5
 testRunner.When("I create a NewsManagementController");
#line 6
 testRunner.Then("a null argument exception will be thrown");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create News Management Controller passing null as the Current User Details Throws" +
            " Arguement Null Exception")]
        public virtual void CreateNewsManagementControllerPassingNullAsTheCurrentUserDetailsThrowsArguementNullException()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create News Management Controller passing null as the Current User Details Throws" +
                    " Arguement Null Exception", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("I have a null current user details");
#line 10
 testRunner.When("I create a NewsManagementController");
#line 11
 testRunner.Then("a null argument exception will be thrown");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("News Management Controller GET Create Action Returns Partial Create View")]
        public virtual void NewsManagementControllerGETCreateActionReturnsPartialCreateView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("News Management Controller GET Create Action Returns Partial Create View", ((string[])(null)));
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I have a mocked service");
#line 15
 testRunner.And("I have a mocked current user details");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content"});
            table1.AddRow(new string[] {
                        "Test Title",
                        "Test Content"});
#line 16
 testRunner.And("I have a news management article with the properties", ((string)(null)), table1);
#line 19
 testRunner.And("I have a News Management Controller");
#line 20
 testRunner.When("I execute the Create GET action");
#line 21
 testRunner.Then("the Create partial view should be rendered");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("News Management Controller POST Create Action Returns Valid Validation Json Resul" +
            "t")]
        public virtual void NewsManagementControllerPOSTCreateActionReturnsValidValidationJsonResult()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("News Management Controller POST Create Action Returns Valid Validation Json Resul" +
                    "t", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
 testRunner.Given("I have a mocked service");
#line 25
 testRunner.And("I have a mocked current user details");
#line 26
 testRunner.And("I have a validation resolver");
#line 27
 testRunner.And("I have a mocked service bus");
#line 28
 testRunner.And("the current user is jonathan");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content"});
            table2.AddRow(new string[] {
                        "Test Title",
                        "Test Content"});
#line 29
 testRunner.And("I have a news management article with the properties", ((string)(null)), table2);
#line 32
 testRunner.And("I have a News Management Controller");
#line 33
 testRunner.When("I execute the Create POST action");
#line 34
 testRunner.Then("a json result will be returned");
#line 35
 testRunner.And("it will contain a validation result");
#line 36
 testRunner.And("the result will be valid");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("News Management Controller POST Create Action Returns Invalid Validation Json Res" +
            "ult")]
        public virtual void NewsManagementControllerPOSTCreateActionReturnsInvalidValidationJsonResult()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("News Management Controller POST Create Action Returns Invalid Validation Json Res" +
                    "ult", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
 testRunner.Given("I have a mocked service");
#line 40
 testRunner.And("I have a mocked current user details");
#line 41
 testRunner.And("I have a validation resolver");
#line 42
 testRunner.And("I have a mocked service bus");
#line 43
 testRunner.And("the current user is jonathan");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content"});
            table3.AddRow(new string[] {
                        "",
                        "Test Content"});
#line 44
 testRunner.And("I have a news management article with the properties", ((string)(null)), table3);
#line 47
 testRunner.And("I have a News Management Controller");
#line 48
 testRunner.When("I execute the Create POST action");
#line 49
 testRunner.Then("a json result will be returned");
#line 50
 testRunner.And("it will contain a validation result");
#line 51
 testRunner.And("the result will be invalid");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("News Management Controller POST Rename Action Returns Valid Validation Json Resul" +
            "t")]
        public virtual void NewsManagementControllerPOSTRenameActionReturnsValidValidationJsonResult()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("News Management Controller POST Rename Action Returns Valid Validation Json Resul" +
                    "t", ((string[])(null)));
#line 53
this.ScenarioSetup(scenarioInfo);
#line 54
 testRunner.Given("I have a mocked service");
#line 55
 testRunner.And("I have a mocked current user details");
#line 56
 testRunner.And("I have a validation resolver");
#line 57
 testRunner.And("I have a mocked service bus");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "CreatedBy",
                        "Title",
                        "Content"});
            table4.AddRow(new string[] {
                        "4f80bc4a-384d-45fc-881a-432b2075d746",
                        "Jonathan",
                        "Test Title",
                        "Test Content"});
#line 58
 testRunner.And("I have a saved news management article with the properties", ((string)(null)), table4);
#line 61
 testRunner.And("I have a News Management Controller");
#line 62
 testRunner.When("I execute the Rename POST action with id as 4f80bc4a-384d-45fc-881a-432b2075d746 " +
                    "and title as New Title");
#line 63
 testRunner.Then("a json result will be returned");
#line 64
 testRunner.And("it will contain a validation result");
#line 65
 testRunner.And("the result will be valid");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("News Management Controller POST Rename Action Returns Invalid Validation Json Res" +
            "ult")]
        public virtual void NewsManagementControllerPOSTRenameActionReturnsInvalidValidationJsonResult()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("News Management Controller POST Rename Action Returns Invalid Validation Json Res" +
                    "ult", ((string[])(null)));
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
 testRunner.Given("I have a mocked service");
#line 69
 testRunner.And("I have a mocked current user details");
#line 70
 testRunner.And("I have a validation resolver");
#line 71
 testRunner.And("I have a mocked service bus");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "CreatedBy",
                        "Title",
                        "Content"});
            table5.AddRow(new string[] {
                        "4f80bc4a-384d-45fc-881a-432b2075d746",
                        "Jonathan",
                        "Test Title",
                        "Test Content"});
#line 72
 testRunner.And("I have a saved news management article with the properties", ((string)(null)), table5);
#line 75
 testRunner.And("I have a News Management Controller");
#line 76
 testRunner.When("I execute the Rename POST action with id as 4f80bc4a-384d-45fc-881a-432b2075d746 " +
                    "and title as nothing");
#line 77
 testRunner.Then("a json result will be returned");
#line 78
 testRunner.And("it will contain a validation result");
#line 79
 testRunner.And("the result will be invalid");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("News Management Controller POST UpdateContent Action Returns Valid Validation Jso" +
            "n Result")]
        public virtual void NewsManagementControllerPOSTUpdateContentActionReturnsValidValidationJsonResult()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("News Management Controller POST UpdateContent Action Returns Valid Validation Jso" +
                    "n Result", ((string[])(null)));
#line 81
this.ScenarioSetup(scenarioInfo);
#line 82
 testRunner.Given("I have a mocked service");
#line 83
 testRunner.And("I have a mocked current user details");
#line 84
 testRunner.And("I have a validation resolver");
#line 85
 testRunner.And("I have a mocked service bus");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "CreatedBy",
                        "Title",
                        "Content"});
            table6.AddRow(new string[] {
                        "4f80bc4a-384d-45fc-881a-432b2075d746",
                        "Jonathan",
                        "Test Title",
                        "Test Content"});
#line 86
 testRunner.And("I have a saved news management article with the properties", ((string)(null)), table6);
#line 89
 testRunner.And("I have a News Management Controller");
#line 90
 testRunner.When("I execute the UpdateContent POST action with id as 4f80bc4a-384d-45fc-881a-432b20" +
                    "75d746 and content as New Content");
#line 91
 testRunner.Then("a json result will be returned");
#line 92
 testRunner.And("it will contain a validation result");
#line 93
 testRunner.And("the result will be valid");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("News Management Controller POST UpdateContent Action Returns Invalid Validation J" +
            "son Result")]
        public virtual void NewsManagementControllerPOSTUpdateContentActionReturnsInvalidValidationJsonResult()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("News Management Controller POST UpdateContent Action Returns Invalid Validation J" +
                    "son Result", ((string[])(null)));
#line 95
this.ScenarioSetup(scenarioInfo);
#line 96
 testRunner.Given("I have a mocked service");
#line 97
 testRunner.And("I have a mocked current user details");
#line 98
 testRunner.And("I have a validation resolver");
#line 99
 testRunner.And("I have a mocked service bus");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "CreatedBy",
                        "Title",
                        "Content"});
            table7.AddRow(new string[] {
                        "4f80bc4a-384d-45fc-881a-432b2075d746",
                        "Jonathan",
                        "Test Title",
                        "Test Content"});
#line 100
 testRunner.And("I have a saved news management article with the properties", ((string)(null)), table7);
#line 103
 testRunner.And("I have a News Management Controller");
#line 104
 testRunner.When("I execute the UpdateContent POST action with id as 4f80bc4a-384d-45fc-881a-432b20" +
                    "75d746 and content as nothing");
#line 105
 testRunner.Then("a json result will be returned");
#line 106
 testRunner.And("it will contain a validation result");
#line 107
 testRunner.And("the result will be invalid");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("News Management Controller GET Edit Action Returns Partial Edit View")]
        public virtual void NewsManagementControllerGETEditActionReturnsPartialEditView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("News Management Controller GET Edit Action Returns Partial Edit View", ((string[])(null)));
#line 109
this.ScenarioSetup(scenarioInfo);
#line 110
 testRunner.Given("I have a mocked service");
#line 111
 testRunner.And("I have a mocked current user details");
#line 112
 testRunner.And("I have a News Management Controller");
#line 113
 testRunner.When("I execute the Edit GET action");
#line 114
 testRunner.Then("the Edit partial view should be rendered");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("News Management Controller GET Delete Action Returns Delete Partial View")]
        public virtual void NewsManagementControllerGETDeleteActionReturnsDeletePartialView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("News Management Controller GET Delete Action Returns Delete Partial View", ((string[])(null)));
#line 116
this.ScenarioSetup(scenarioInfo);
#line 117
 testRunner.Given("I have a mocked service");
#line 118
 testRunner.And("I have a mocked current user details");
#line 119
 testRunner.And("I have a News Management Controller");
#line 120
 testRunner.When("I execute the Delete GET action");
#line 121
 testRunner.Then("the Delete partial view should be rendered");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("News Management Controller POST Delete Action Returns Valid Validation Json Resul" +
            "t")]
        public virtual void NewsManagementControllerPOSTDeleteActionReturnsValidValidationJsonResult()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("News Management Controller POST Delete Action Returns Valid Validation Json Resul" +
                    "t", ((string[])(null)));
#line 123
this.ScenarioSetup(scenarioInfo);
#line 124
 testRunner.Given("I have a mocked service");
#line 125
 testRunner.And("I have a mocked current user details");
#line 126
 testRunner.And("I have a validation resolver");
#line 127
 testRunner.And("I have a mocked service bus");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "CreatedBy",
                        "Title",
                        "Content"});
            table8.AddRow(new string[] {
                        "4f80bc4a-384d-45fc-881a-432b2075d746",
                        "Jonathan",
                        "Test Title",
                        "Test Content"});
#line 128
 testRunner.And("I have a saved news management article with the properties", ((string)(null)), table8);
#line 131
 testRunner.And("I have a News Management Controller");
#line 132
 testRunner.When("I execute the Delete POST action with id as 4f80bc4a-384d-45fc-881a-432b2075d746");
#line 133
 testRunner.Then("a json result will be returned");
#line 134
 testRunner.And("it will contain a validation result");
#line 135
 testRunner.And("the result will be valid");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("News Management Controller POST Delete Action Returns Invalid Validation Json Res" +
            "ult")]
        public virtual void NewsManagementControllerPOSTDeleteActionReturnsInvalidValidationJsonResult()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("News Management Controller POST Delete Action Returns Invalid Validation Json Res" +
                    "ult", ((string[])(null)));
#line 137
this.ScenarioSetup(scenarioInfo);
#line 138
 testRunner.Given("I have a mocked service");
#line 139
 testRunner.And("I have a mocked current user details");
#line 140
 testRunner.And("I have a validation resolver");
#line 141
 testRunner.And("I have a mocked service bus");
#line 142
 testRunner.And("I do not have a saved news management article with the identifier 4f80bc4a-384d-4" +
                    "5fc-881a-432b2075d746");
#line 143
 testRunner.And("I have a News Management Controller");
#line 144
 testRunner.When("I execute the Delete POST action with id as 4f80bc4a-384d-45fc-881a-432b2075d746");
#line 145
 testRunner.Then("a json result will be returned");
#line 146
 testRunner.And("it will contain a validation result");
#line 147
 testRunner.And("the result will be invalid");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("News Management Controller GetNewsArticleForUpdateOrDelete Action Returns News Ma" +
            "nagement Article Json Result")]
        public virtual void NewsManagementControllerGetNewsArticleForUpdateOrDeleteActionReturnsNewsManagementArticleJsonResult()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("News Management Controller GetNewsArticleForUpdateOrDelete Action Returns News Ma" +
                    "nagement Article Json Result", ((string[])(null)));
#line 149
this.ScenarioSetup(scenarioInfo);
#line 150
 testRunner.Given("I have a mocked service");
#line 151
 testRunner.And("I have a mocked current user details");
#line 152
 testRunner.And("I have a validation resolver");
#line 153
 testRunner.And("I have a mocked service bus");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "CreatedBy",
                        "Title",
                        "Content"});
            table9.AddRow(new string[] {
                        "4f80bc4a-384d-45fc-881a-432b2075d746",
                        "Jonathan",
                        "Test Title",
                        "Test Content"});
#line 154
 testRunner.And("I have a saved news management article with the properties", ((string)(null)), table9);
#line 157
 testRunner.And("I have a News Management Controller");
#line 158
 testRunner.When("I execute the GetNewsArticleForUpdateOrDelete GET action with id as 4f80bc4a-384d" +
                    "-45fc-881a-432b2075d746");
#line 159
 testRunner.Then("a json result will be returned");
#line 160
 testRunner.And("it will contain a news management article");
#line 161
 testRunner.And("the json news management article Id will be 4f80bc4a-384d-45fc-881a-432b2075d746");
#line 162
 testRunner.And("the json news management article CreatedBy will be Jonathan");
#line 163
 testRunner.And("the json news management article Title will be Test Title");
#line 164
 testRunner.And("the json news management article Content will be Test Content");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("News Management Controller GetNewsArticleForUpdateOrDelete Action Returns a null " +
            "Json Result")]
        public virtual void NewsManagementControllerGetNewsArticleForUpdateOrDeleteActionReturnsANullJsonResult()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("News Management Controller GetNewsArticleForUpdateOrDelete Action Returns a null " +
                    "Json Result", ((string[])(null)));
#line 166
this.ScenarioSetup(scenarioInfo);
#line 167
 testRunner.Given("I have a mocked service");
#line 168
 testRunner.And("I have a mocked current user details");
#line 169
 testRunner.And("I have a validation resolver");
#line 170
 testRunner.And("I have a mocked service bus");
#line 171
 testRunner.And("I do not have a saved news management article with the identifier 4f80bc4a-384d-4" +
                    "5fc-881a-432b2075d746");
#line 172
 testRunner.And("I have a News Management Controller");
#line 173
 testRunner.When("I execute the GetNewsArticleForUpdateOrDelete GET action with id as 4f80bc4a-384d" +
                    "-45fc-881a-432b2075d746");
#line 174
 testRunner.Then("a json result will be returned");
#line 175
 testRunner.And("the json result it will be null");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#endregion
