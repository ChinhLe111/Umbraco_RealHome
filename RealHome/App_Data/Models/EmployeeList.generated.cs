//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v8.18.5
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder.Embedded;

namespace Umbraco.Web.PublishedModels
{
	// Mixin Content Type with alias "employeeList"
	/// <summary>EmployeeList</summary>
	public partial interface IEmployeeList : IPublishedElement
	{
		/// <summary>Employee_List</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.EmployeeItem> Employee_List { get; }
	}

	/// <summary>EmployeeList</summary>
	[PublishedModel("employeeList")]
	public partial class EmployeeList : PublishedElementModel, IEmployeeList
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public new const string ModelTypeAlias = "employeeList";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<EmployeeList, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public EmployeeList(IPublishedElement content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Employee_List
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		[ImplementPropertyType("employee_List")]
		public virtual global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.EmployeeItem> Employee_List => GetEmployee_List(this);

		/// <summary>Static getter for Employee_List</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public static global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.EmployeeItem> GetEmployee_List(IEmployeeList that) => that.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.EmployeeItem>>("employee_List");
	}
}
