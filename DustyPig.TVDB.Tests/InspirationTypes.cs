﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class InspirationTypes
    {
        [TestMethod]
        public async Task GetAll()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.InspirationTypes.GetAllAsync();
            ret.ThrowIfError();
        }
    }
}