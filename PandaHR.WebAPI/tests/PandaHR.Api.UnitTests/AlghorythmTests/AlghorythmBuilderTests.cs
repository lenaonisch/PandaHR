﻿using PandaHR.Api.Services.ScoreAlgorithm;
using PandaHR.Api.Services.ScoreAlgorithm.Models;
using System;
using Xunit;

namespace PandaHR.Api.UnitTests.AlghorythmTests.Tests
{
    public class AlghorythmBuilderTests : IClassFixture<AlghorythmTestSeed>
    {
        private readonly ScoreAlghorythmBuilder _alghorythmBuilder;

        public AlghorythmBuilderTests(AlghorythmTestSeed testSeed)
        {
            _alghorythmBuilder = testSeed.AlghorythmBuilder;
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1, 2, 2)]
        [InlineData(2, 1, 2)]
        public void InvalidSkillTypeThrowExeptionGetScoreAlghorythmTest(int hardSkillValue, int langSkillValue, int softSkillValue)
        {
            SkillTypeValues skillTypeValues = new SkillTypeValues()
            {
                HardSkillsValue = hardSkillValue,
                LanguageSkillsValue = langSkillValue,
                SoftSkillsValue = softSkillValue
            };
            KnowledgeScaleSteps knowledgeScaleSteps = new KnowledgeScaleSteps()
            {
                HardKnowledgeScaleStep = 6,
                LanguageKnowledgeScaleStep = 6,
                QualificationScaleStep = 6,
                SoftKnowledgeScaleStep = 6
            };

            //Assert & Act
            Assert.Throws<ArgumentException>(() => _alghorythmBuilder.GetScoreAlghorythm(skillTypeValues, knowledgeScaleSteps));
        }

        [Theory]
        [InlineData(1, 1, 1, 0)]
        [InlineData(1, 1, 0, 1)]
        [InlineData(1, 0, 1, 1)]
        [InlineData(0, 1, 1, 1)]
        [InlineData(0, 0, 1, 1)]
        public void InvalidKnowledgeScaleStepGetScoreAlghorythmTest(int hardKnowledgeScaleStep,
            int languageKnowledgeScaleStep, int qualificationScaleStep, int softKnowledgeScaleStep)
        {
            //Arrange
            SkillTypeValues skillTypeValues = new SkillTypeValues()
            {
                HardSkillsValue = 1,
                LanguageSkillsValue = 2,
                SoftSkillsValue = 3
            };
            KnowledgeScaleSteps knowledgeScaleSteps = new KnowledgeScaleSteps()
            {
                HardKnowledgeScaleStep = hardKnowledgeScaleStep,
                LanguageKnowledgeScaleStep = languageKnowledgeScaleStep,
                QualificationScaleStep = qualificationScaleStep,
                SoftKnowledgeScaleStep = softKnowledgeScaleStep
            };

            //Assert & Act
            Assert.Throws<ArgumentException>(() => _alghorythmBuilder.GetScoreAlghorythm(skillTypeValues, knowledgeScaleSteps));
        }

        [Fact]
        public void GetScoreAlghorythmTest()
        {
            //Arrange
            ScoreAlghorythm alghorythm;
            SkillTypeValues skillTypeValues = new SkillTypeValues()
            {
                HardSkillsValue = 1,
                LanguageSkillsValue = 2,
                SoftSkillsValue = 3
            };
            KnowledgeScaleSteps knowledgeScaleSteps = new KnowledgeScaleSteps()
            {
                HardKnowledgeScaleStep = 6,
                LanguageKnowledgeScaleStep = 6,
                QualificationScaleStep = 6,
                SoftKnowledgeScaleStep = 6
            };

            //Act
            alghorythm = _alghorythmBuilder.GetScoreAlghorythm(skillTypeValues, knowledgeScaleSteps);

            //Assert 
            Assert.True(alghorythm != null);
        }
    }
}
