﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoFramework.Infrastructure.Mapping;
using MongoFramework.Infrastructure.Mapping.Processors;

namespace MongoFramework.Tests.Infrastructure.Mapping.Processors
{
	[TestClass]
	public class CollectionNameProcessorTests : MappingTestBase
	{
		[Table("CustomCollection")]
		public class CustomCollectionModel
		{
		}

		[Table("CustomCollection", Schema = "CustomSchema")]
		public class CustomCollectionAndSchemaModel
		{
		}

		public class DefaultCollectionNameModel
		{
		}


		[TestMethod]
		public void CollectionNameFromClassName()
		{
			EntityMapping.AddMappingProcessor(new CollectionNameProcessor());
			var definition = EntityMapping.RegisterType(typeof(DefaultCollectionNameModel));
			Assert.AreEqual("DefaultCollectionNameModel", definition.CollectionName);
		}

		[TestMethod]
		public void CollectionNameFromAttribute()
		{
			EntityMapping.AddMappingProcessor(new CollectionNameProcessor());
			var definition = EntityMapping.RegisterType(typeof(CustomCollectionModel));
			Assert.AreEqual("CustomCollection", definition.CollectionName);
		}

		[TestMethod]
		public void CollectionNameAndSchemaFromAttribute()
		{
			EntityMapping.AddMappingProcessor(new CollectionNameProcessor());
			var definition = EntityMapping.RegisterType(typeof(CustomCollectionAndSchemaModel));
			Assert.AreEqual("CustomSchema.CustomCollection", definition.CollectionName);
		}
	}
}
