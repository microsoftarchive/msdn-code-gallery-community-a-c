// =====================================================================
//  This file is part of the Microsoft Dynamics CRM SDK code samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
// =====================================================================

using Microsoft.Crm.Sdk.Messages.Samples;
using Microsoft.Xrm.Sdk.Samples;
using Microsoft.Xrm.Sdk.Metadata.Samples;
using System;
using System.Collections.Generic;

namespace CRMtoGo.DataModel
{
    // This class presents a record for a grid. It has 3 fields to display, Record Id
    // ActivityTypeName in case this is activity, and PrimaryFieldValue in case this is lookup
    public class ViewData
    {
        public ViewData()
        {
        }
        public ViewData(Guid id, object first, object second, object third, string activityTypeName = null, string primaryFieldValue = null)
        {
            this.Id = id;
            this.First = first;
            this.Second = second;
            this.Third = third;
            this.ActivityTypeName = activityTypeName;
            this.PrimaryFieldValue = primaryFieldValue;
        }
        
        // Record Id
        public Guid Id { get; internal set; }
        // Data for first column
        public object First { get; internal set; }
        // Data for second column
        public object Second { get; internal set; }
        // Data for third column
        public object Third { get; internal set; }
        // ActivityType Logical Name for activity type record
        public string ActivityTypeName { get; internal set; }
        // Data for Entity PrimaryName field.
        public string PrimaryFieldValue { get; internal set; }
    }

    // Field data and its AttributeMetadata for record form
    public class FormFieldData
    {
        // Constructors
        public FormFieldData()
        {
        }
        public FormFieldData(AttributeMetadata fieldMetadata)
        {
            this.FieldMetadata = fieldMetadata;
        }
        // Field value
        public object FieldData { get; set; }
        // Field Metadata
        public AttributeMetadata FieldMetadata { get; set; }
        // attribute mapping information for N:1 (lookup)
        public List<MyAttributeMap> AttributeMaps { get; set; }
    }

    // This extend class holds EntityMetadata and it's Related Entities which is available for app.
    public class EntityMetadataEx
    {
        public EntityMetadata EntityMetadata { get; set; }
        public DataCollection<RelatedData> RelatedEntities { get; set; }
        // Constructors
        public EntityMetadataEx()
        {
        }
        public EntityMetadataEx(EntityMetadata entityMetadata, DataCollection<RelatedData> relatedEntities)
        {
            this.EntityMetadata = entityMetadata;
            this.RelatedEntities = relatedEntities;
        }
    }

    // Collection of EntityMetadataEx
    public class EntityMetadataExCollection : List<EntityMetadataEx>
    {
        public EntityMetadataExCollection()
        {
        }
    }

    // This extended class holds Related Entities information for main entities.
    // 1:N, N:N relationship metadata are converd.
    public class RelatedData
    {
        public string DisplayName { get; set; }
        public int ObjectTypeCode { get; set; }
        // From Entity
        public string ReferencedEntity { get; set; }
        // From Attirbute
        public string ReferencedAttribute { get; set; }
        // To Entity
        public string ReferencingEntity { get; set; }
        // To Attribute
        public string ReferencingAttribute { get; set; }
        // For N:N relationship.
        public string IntersectEntityName { get; set; }
        // logical name of the relationship
        public string SchemaName { get; set; }
        // From record Id
        public Guid Id { get; set; }
        // Stores relationship mapping information.
        public List<MyAttributeMap> AttributeMaps { get; set; }
        public RelatedData()
        {
        }
    }

    // Stored attributes mapping information 
    // Though we have exaclty same information for generated data, to make it simple 
    // and to serialize/deserialize, I redefine this with all the properties as public.
    public class MyAttributeMap
    {
        // Constructors
        public MyAttributeMap()
        {
        }
        public MyAttributeMap(string sourceAttributeName, string targetAttributeName, Guid entityMapId)
        {
            this.SourceAttributeName = sourceAttributeName;
            this.TargetAttributeName = targetAttributeName;
            this.EntityMapId = entityMapId;
        }

        public string SourceAttributeName { get; set; }
        public string TargetAttributeName { get; set; }
        public Guid EntityMapId { get; set; }
    }

    // Stored entity mapping information  (1:N to AttributeMap)
    // Though we have exaclty same information for generated data, to make it simple 
    // and to serialize/deserialize, I redefine this with all the properties as public.
    public class MyEntityMap
    {
        public MyEntityMap()
        {
        }
        public MyEntityMap(string sourceEntityName, string targetEntityName, Guid entityMapId)
        {
            this.SourceEntityName = sourceEntityName;
            this.TargetEntityName = targetEntityName;
            this.EntityMapId = entityMapId;
        }
        public string SourceEntityName { get; set; }
        public string TargetEntityName { get; set; }
        public Guid EntityMapId { get; set; }
    }


    // Store UserPrivilege information with Privilege Name (i.e. prvCreateAccount)
    // As using Guid is difficult to understand.
    public class UserPrivilege
    {
        public RolePrivilege RolePrivilege { get; set; }
        public string PrivilegeName { get; set; }
        public UserPrivilege()
        {
        }
    }
}
