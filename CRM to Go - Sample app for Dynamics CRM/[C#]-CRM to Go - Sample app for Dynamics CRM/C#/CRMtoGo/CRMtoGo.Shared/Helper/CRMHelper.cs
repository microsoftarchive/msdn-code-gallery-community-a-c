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

using CRMtoGo.DataModel;
using CRMtoGo.Pages;
using Microsoft.Crm.Sdk.Messages.Samples;
using Microsoft.Xrm.Sdk.Messages.Samples;
using Microsoft.Xrm.Sdk.Metadata.Query.Samples;
using Microsoft.Xrm.Sdk.Metadata.Samples;
using Microsoft.Xrm.Sdk.Query.Samples;
using Microsoft.Xrm.Sdk.Samples;
using MyTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;

// Xamarin Incompatible Namespace
using CRMtoGo.CustomControls;
using Windows.Globalization;
using Windows.Security.Authentication.Web;
using Windows.Storage;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace CRMtoGo.Common
{
    /// <summary>
    /// This helper class provides 1. Metadata for application. 2. Methods which calls CRM Service at the end.
    /// This class is marked static, means any page in this application has access to it.
    /// </summary>
    static public class CRMHelper
    {
        #region class member

        // Use temporaryData to pass parameters between pages.
        // When passig complex type as parameter for Frame.Navigate method, SuspensionManager
        // may generate error.
        static public object temporaryData { get; set; }

        // Organization Service Proxy
        static public OrganizationDataWebServiceProxy _proxy;

        // Store all Entity Metadata for application.
        static public EntityMetadataExCollection EntityMetadataExCollection { get; internal set; }
        // Store Entity names which represents SiteMap
        static public List<string> SiteMapEntities { get; internal set; }
        // Current user information
        static public SystemUser UserInfo { get; internal set; }
        // Current user settings
        static public UserSettings UserSettings { get; internal set; }
        // CRM Timezones
        static public DataCollection<TimeZoneDefinition> TimeZones { get; internal set; }

        // Curren user privilegdge
        static private List<UserPrivilege> userPrivileges;
        // Metadata Version
        static private string serverVersionStamp;
        
        #region Culture LCID and Name

        static private Dictionary<int, string> LCIDandTAG = new Dictionary<int, string>
        { 
            {1033, "en-US"},
            {1041, "ja-JP"},
            {2052, "zh-CN"},
            {1040, "it"},
            {1031, "de"},
            {1036, "fr"},
            {1034, "es"},
        };

        #endregion
        
        #region ADAL related

        // RedirectUri. Value will be changed when you register this app to store, so that 
        // you need to re-register to Azure AD.
        static public string RedirectUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().ToString();
        // ClientId which you need to obtain from Azure Portal.
        // See http://msdn.microsoft.com/en-us/library/dn531010.aspx for more detail
        static public string ClientId = "30a788f2-dce6-418d-bc9a-e272a658edac";
        static public string OAuthUrl { get; set; }
        static public string ResourceName { get; set; }
        // Indicate if user Signed Out from system.
        static public bool SignOut { get; set; }
        // Indicate if data for this class have been loaded.
        static public bool IsLoaded { get; set; }

        #endregion

        #endregion

        /// <summary>
        /// Constractor. Assing nesesarry values here.
        /// </summary>
        static CRMHelper()
        {
            IsLoaded = false;
            _proxy = new OrganizationDataWebServiceProxy();
            // The reason why separate LoadData method is because i cannot use async for static constructor.
            // Instead await, mark IsLoaded to false until load finishes.
            LoadData();
        }

        /// <summary>
        /// Load data from cache. 
        /// </summary>
        static async void LoadData()
        {
            // Load ServiceUrl. If its null (when serverUrl is not set, it is handled in MainPage
            _proxy.ServiceUrl = ResourceName = (string)await Util.ReadFromLocal<string>("serverUrl.dat");

            // Mark IsLoaded to true when all data loaded.
            IsLoaded = true;
        }

        /// <summary>
        /// Retrieve OAuth Url. See http://msdn.microsoft.com/en-us/library/dn531009.aspx#bkmk_oauth_discovery for detail.
        /// Only available for Microsoft Dynamics CRM 2013 SP1 or later.
        /// </summary>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task DiscoveryAuthority()
        {
            // Service URL had to be set before retrieving OAuth URL
            if (String.IsNullOrEmpty(CRMHelper._proxy.ServiceUrl))
                return;

            // Try load from cache.
            OAuthUrl = (string)await Util.ReadFromLocal<string>("OAuthUrl.dat");

            // If no cache available, then retrieve with query.
            if (String.IsNullOrEmpty(OAuthUrl))
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
                    // need to specify soap endpoint with client version,.
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(
                        CRMHelper._proxy.ServiceUrl + "/XRMServices/2011/Organization.svc/web?SdkClientVersion=6.1.0.533");
                    // For phone, we dont need oauth2/authorization part.
                    OAuthUrl =  AuthenticationParameters.CreateFromResponseAuthenticateHeader(httpResponse.Headers.WwwAuthenticate.ToString()).Authority;
        
                    await Util.SaveToLocal(OAuthUrl, "OAuthUrl.dat");
                }
            }
        }

        #region Application methods

        /// <summary>
        /// This method initializes properties.
        /// </summary>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task Initialize()
        {
            // To support Earlybound
            await _proxy.EnableProxyTypes();

            // Make timeout to 10 minutes (mainly to cover metadata interaction)
            _proxy.Timeout = 600;

            try
            {
                // Make sure AccessToken is valid.
                await Util.EnsureToken();

                await RetrieveUserInfo();
                SetAppLanguage();
                await RetrieveTimeZone();
                await RetrieveSiteMap();
                await RetrieveUserPrivilege();
                await RetrieveEntityMetadata();
                
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        #region User and Metadata Initialization

        /// <summary>
        /// This method retrive current user and usersettings information.
        /// </summary>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task RetrieveUserInfo()
        {
            // try to restore from cache
            UserInfo = (SystemUser)await Util.ReadFromLocal<SystemUser>("UserInfo.dat");
            UserSettings = (UserSettings)await Util.ReadFromLocal<UserSettings>("UserSettings.dat");

            // If there is no cache, then retireve them from server.
            if (UserInfo != null && UserSettings != null)
                return;

            // Check current user ID
            WhoAmIResponse whoAmIResponse = (WhoAmIResponse)await _proxy.Execute(new WhoAmIRequest());
            // Retrieve User Info
            UserInfo = (SystemUser)await _proxy.Retrieve(SystemUser.EntityLogicalName, whoAmIResponse.UserId, new ColumnSet(true));
            // Retrieve User Settings
            QueryExpression userSettingsQuery = new QueryExpression(UserSettings.EntityLogicalName);
            userSettingsQuery.ColumnSet = new ColumnSet(true);
            userSettingsQuery.Criteria.AddCondition("systemuserid", ConditionOperator.Equal, UserInfo.SystemUserId);
            // Each user must have an UserSettings
            UserSettings = (await _proxy.RetrieveMultiple(userSettingsQuery)).Entities.First() as UserSettings;

            // Caching
            await Util.SaveToLocal(UserInfo, "UserInfo.dat");
            await Util.SaveToLocal(UserSettings, "UserSettings.dat");
        }

        /// <summary>
        /// Retrieves CRM TimeZone information.
        /// </summary>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task RetrieveTimeZone()
        {
            // try to restore from cache
            TimeZones = (DataCollection<TimeZoneDefinition>)await Util.ReadFromLocal<DataCollection<TimeZoneDefinition>>("TimeZones.dat");

            // If there is no cache, then retireve them from server.
            if (TimeZones != null)
                return;
    
            TimeZones = new DataCollection<TimeZoneDefinition>();
            // Use GetAllTimeZoneWithDisplaynameRequest with correct UILanguageId
            GetAllTimeZonesWithDisplayNameResponse response = (GetAllTimeZonesWithDisplayNameResponse)await CRMHelper._proxy.Execute(
                new GetAllTimeZonesWithDisplayNameRequest
                {
                    // If no UILanguage set yet, then use LocalId instead.
                    LocaleId = ((int)UserSettings.UILanguageId == 0) ? (int)UserSettings.LocaleId : (int)UserSettings.UILanguageId,
                });
            foreach (TimeZoneDefinition result in response.EntityCollection.Entities.OrderByDescending(x => (x as TimeZoneDefinition).Bias))
            {
                TimeZones.Add(result);
            }
            await Util.SaveToLocal(TimeZones, "TimeZones.dat");
        }

        /// <summary>
        /// This method retrieve Sitemap information
        /// </summary>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task RetrieveSiteMap()
        {
            // try to restore from cache
            SiteMapEntities = (List<string>)await Util.ReadFromLocal<List<string>>("SiteMapEntities.dat");

            // If there is no cache, then retireve them from server.
            if (SiteMapEntities != null)
                return;

            SiteMapEntities = new List<string>();
            // Retrieve SiteMap. There should be 1 record.
            SiteMap result = (SiteMap)(await _proxy.RetrieveMultiple(new QueryExpression(SiteMap.EntityLogicalName, new ColumnSet(true)))).Entities[0];

            // Parse SiteMapXml to retireve entity names.
            XDocument doc = XDocument.Parse(result.SiteMapXml);
            foreach (XElement sub in doc.Descendants("SubArea"))
            {
                XAttribute entity = sub.Attribute("Entity");
                // If SubArea has Entity attribute and SiteMapEntities list doesn't have value yet, then add it.
                if (entity != null && !SiteMapEntities.Contains(entity.Value))
                    SiteMapEntities.Add(entity.Value);
            }

            // Caching
            await Util.SaveToLocal(SiteMapEntities, "SiteMapEntities.dat");
        }

        /// <summary>
        /// Retrieves Privileges assigned to user.
        /// </summary>
        /// <returns></returns>
        static private async System.Threading.Tasks.Task RetrieveUserPrivilege()
        {
            // Retrieve all the assigned Privileges for current user.
            // Try to restore from local cache
            userPrivileges = (List<UserPrivilege>)await Util.ReadFromLocal<List<UserPrivilege>>("UserPrivilege.dat");
            if (userPrivileges != null)
                return;

            // If there is no cache date, then retrieve it from server.
            RolePrivilege[] userPrivs = ((RetrieveUserPrivilegesResponse)await _proxy.Execute(
                new RetrieveUserPrivilegesRequest()
                {
                    UserId = (Guid)UserInfo.SystemUserId
                })).RolePrivileges;

            // Obtain all the privilege Guids. Though PrivilegeId is Guid, QueryExpression need object collection.
            DataCollection<object> ids = new DataCollection<object>();
            foreach (RolePrivilege userPriv in userPrivs)
            {
                ids.Add(userPriv.PrivilegeId);
            }

            // Then retrieve privilege name information
            QueryExpression qe = new QueryExpression()
            {
                EntityName = Privilege.EntityLogicalName,
                ColumnSet = new ColumnSet(true),
                Criteria =
                {
                    Conditions = { new ConditionExpression() { AttributeName = "privilegeid", Operator = ConditionOperator.In, Values = ids } }
                }
            };
            var userPrivNames = await _proxy.RetrieveMultiple(qe);

            // Finally store them all together and cache to local.
            userPrivileges = new List<UserPrivilege>();
            foreach (RolePrivilege userPriv in userPrivs)
            {
                UserPrivilege userPrivilege = new UserPrivilege();
                userPrivilege.RolePrivilege = userPriv;
                userPrivilege.PrivilegeName = userPrivNames.Entities.Where(x => x.Id == userPriv.PrivilegeId).First().Attributes["name"].ToString();
                userPrivileges.Add(userPrivilege);
            }

            // Finally cache it
            await Util.SaveToLocal(userPrivileges, "UserPrivilege.dat");
        }

        /// <summary>
        /// Retrieves EntityMetadata and Mappings information.
        /// </summary>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task RetrieveEntityMetadata()
        {
            // Try to restore from cache
            EntityMetadataExCollection = (EntityMetadataExCollection)await Util.ReadFromLocal<EntityMetadataExCollection>("EntityMetadataExCollection.dat");
            serverVersionStamp = (string)await Util.ReadFromLocal<string>("serverVersionStamp.dat");
            
            // If there is no cache, then retireve them from server.
            // For consistency, if any of above item is null, then retrieve everything again.
            if (EntityMetadataExCollection != null)
                return;

            // Initialize collection
            EntityMetadataExCollection = new EntityMetadataExCollection();

            // Create MetadataQuery
            // Create Filter for Entity.
            MetadataFilterExpression EntityFilter = new MetadataFilterExpression(LogicalOperator.Or);
            // In this sample, I only retrieve entity which marks as IsVisibleInMobileClient to True.
            MetadataConditionExpression isVisibileInMobileTrue = new MetadataConditionExpression("IsVisibleInMobile", MetadataConditionOperator.Equals, true);
            EntityFilter.Conditions.Add(isVisibileInMobileTrue);
            // In addition, I need Currency, UserSettings too. As these entitis are not makes as IsVisibleInMobileClient=True, include them explicitly.
            EntityFilter.Conditions.Add(new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, "transactioncurrency"));
            EntityFilter.Conditions.Add(new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, "usersettings"));

            // To save cache data and memory, retireve only attributes you want.
            MetadataPropertiesExpression EntityProperties = new MetadataPropertiesExpression()
            {
                AllProperties = false // do not retireve all properties. 
            };
            // And you specify which Entity properties you want to get
            EntityProperties.PropertyNames.AddRange(new string[] {
                "Attributes", // Need Attibutes information to store Attribute Metadata
                "DisplayName", // Entity Display Name (i.e. Account)
                "DisplayCollectionName", // Entity Plural Name (i.e. Accounts)
                "LogicalName", // LogicalName (i.e. account)
                "SchemaName", // SchemaName (i.e. Account)
                "PrimaryNameAttribute", // Primary Name (i.e. Name)
                "PrimaryImageAttribute", // Primary Image (always EntityImage. Retrieve this to check if the entity has image support)
                "PrimaryIdAttribute", // Primary Id (i.e. AccountId)
                "ObjectTypeCode", // ObjectTypeCode (i.e. 1)
                "ManyToManyRelationShips", // N:N relationship
                "ManyToOneRelationShips", // N:1 relationship
                "OneToManyRelationships", // lookups
                "IsVisibleInMobile",
                "IsActivity"});

            // Create Attribute Filter next. 
            MetadataFilterExpression AttributeFilter = new MetadataFilterExpression(LogicalOperator.Or);
            MetadataConditionExpression attributeOfContainsData = new MetadataConditionExpression("AttributeOf", MetadataConditionOperator.Equals, null);
            MetadataConditionExpression attributeEntityImageId = new MetadataConditionExpression("AttributeOf", MetadataConditionOperator.Equals, "entityimageid");

            AttributeFilter.Conditions.Add(attributeOfContainsData);
            AttributeFilter.Conditions.Add(attributeEntityImageId);

            // Specify which attribute property you want to retrieve. As I need Attribute Metadata, retrieving all properties.
            MetadataPropertiesExpression AttributeProperties = new MetadataPropertiesExpression()
            {
                AllProperties = true // retireve all properties. 
            };

            //A label query expression to limit the labels returned to only those for the user's preferred language
            LabelQueryExpression labelQuery = new LabelQueryExpression();
            labelQuery.FilterLanguages.Add((int)UserSettings.UILanguageId.Value);

            EntityQueryExpression entityQueryExpression = new EntityQueryExpression()
            {
                Criteria = EntityFilter,
                Properties = EntityProperties,
                AttributeQuery = new AttributeQueryExpression()
                {
                    //Criteria = AttributeFilter,
                    Properties = AttributeProperties
                },
                LabelQuery = labelQuery
            };

            // Finally retrieve it.
            RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest()
            {
                Query = entityQueryExpression,
                // Specify null to retireve all metadata. If you want to retrieve only difference data, then specify last retrieved ClintVersionStamp.
                ClientVersionStamp = null,
                DeletedMetadataFilters = DeletedMetadataFilters.Entity // Specify which deleted information you need to get
            };
            // Retrieve Metadata
            RetrieveMetadataChangesResponse retrieveMetadataChangesResponse = (RetrieveMetadataChangesResponse)await _proxy.Execute(retrieveMetadataChangesRequest);
            // Store results temporary here
            EntityMetadataCollection results = retrieveMetadataChangesResponse.EntityMetadata;

            // Store version number
            serverVersionStamp = retrieveMetadataChangesResponse.ServerVersionStamp;
            // Save to cache
            await Util.SaveToLocal(serverVersionStamp, "serverVersionStamp.dat");

            // Instantiate new collection which store final results.
            EntityMetadataCollection entityMetadataCollection = new EntityMetadataCollection();

            // Remove Entities which user does not have read access
            foreach (var item in results)
            {
                string schemaName;
                // If it is acvitivy entity, like phonecall, task, then consider it as Activity
                if (item.IsActivity == true)
                    schemaName = "Activity";
                // otherwise use its SchemaName
                else
                    schemaName = item.SchemaName;

                // Check read privilege (basic)
                bool result = CRMHelper.CheckPrivilege(schemaName, PrivilegeType.Read, PrivilegeDepth.Basic);

                // if user has Read access, then store it.
                if (result)
                    entityMetadataCollection.Add(item);
            }

            // Retrieve 1:N mapping information for each entity. Firstly retrieve EntityMap and AttributeMap

            // Only get EntityMaps which are used in this application.
            // Though LogicalName is String type, to use it in QueryExpression, create object Array
            DataCollection<object> entityNames = new DataCollection<object>();
            entityNames.AddRange(entityMetadataCollection.Select(x => x.LogicalName).ToArray());

            // Create Query to retrieve EntityMap
            QueryExpression entitymapQuery = new QueryExpression()
            {
                EntityName = EntityMap.EntityLogicalName,
                ColumnSet = new ColumnSet("sourceentityname", "targetentityname"),
                Criteria = new FilterExpression
                {
                    Conditions = 
                        {
                            new ConditionExpression 
                            {
                                // where SourceEntityName is (entity names)
                                AttributeName = "sourceentityname",
                                Operator = ConditionOperator.In,
                                Values = entityNames
                            }
                        }
                }
            };

            // Instantiate EntityMaps
            List<MyEntityMap> EntityMaps = new List<MyEntityMap>();

            // Loop retrieved EntityMap and add it to EntityMaps list.
            foreach (EntityMap entityMap in (await _proxy.RetrieveMultiple(entitymapQuery)).Entities)
            {
                EntityMaps.Add(new MyEntityMap(entityMap.SourceEntityName, entityMap.TargetEntityName, entityMap.Id));
            }
            // Save to cache
            await Util.SaveToLocal(EntityMaps, "EntityMaps.dat");


            // Do the same to AttributeMaps

            // Retrieve AttributeMaps only related EntityMaps retrieved above.
            // Though EntityMapId is Guid type, to use it in QueryExpression, create object Array
            DataCollection<object> entityMapIds = new DataCollection<object>();
            foreach (MyEntityMap entityMap in EntityMaps)
            {
                entityMapIds.Add(entityMap.EntityMapId);
            }

            // Only get AttributeMaps which are used in this app.
            QueryExpression attributemapQuery = new QueryExpression()
            {
                EntityName = AttributeMap.EntityLogicalName,
                ColumnSet = new ColumnSet("entitymapid", "sourceattributename", "targetattributename"),
                Criteria = new FilterExpression
                {
                    Conditions = 
                        {
                            new ConditionExpression 
                            {
                                AttributeName = "entitymapid",
                                Operator = ConditionOperator.In,
                                Values = entityMapIds
                            },
                            new ConditionExpression
                            {
                                AttributeName="parentattributemapid",
                                Operator = ConditionOperator.Null
                            }
                        }
                }
            };

            // Instantiate AttributeMaps
            List<MyAttributeMap> AttributeMaps = new List<MyAttributeMap>();

            // Loop retrieved AttributeMap and add it to AttributeMaps list.
            foreach (AttributeMap attributeMap in (await _proxy.RetrieveMultiple(attributemapQuery)).Entities)
            {
                AttributeMaps.Add(new MyAttributeMap(attributeMap.SourceAttributeName, attributeMap.TargetAttributeName, attributeMap.EntityMapId.Id));
            }
            // Cache this one, too
            await Util.SaveToLocal(AttributeMaps, "AttributeMaps.dat");

            // Once EntityMap and AttributeMap retrieved, then join them to generate 1:N mapping information.

            // List of entity logical names
            List<string> list = entityMetadataCollection.Select(x => x.LogicalName).ToList();

            // Store related and mapping information to EntityMetadataEx
            foreach (var em in entityMetadataCollection)
            {
                // Obtain 1:N relationship 
                DataCollection<RelatedData> relatedEntities = new DataCollection<RelatedData>();
                List<OneToManyRelationshipMetadata> omm = new List<OneToManyRelationshipMetadata>();
                foreach (var om in em.OneToManyRelationships)
                {
                    // Only add related entities which are marked to be displayed in SiteMap/Navigation, and available for this app.
                    if (om.AssociatedMenuConfiguration.Behavior.Value != AssociatedMenuBehavior.DoNotDisplay && list.Contains(om.ReferencingEntity))
                    {
                        omm.Add(om);
                        RelatedData relatedData = new RelatedData();
                        // Store Displayname
                        relatedData.DisplayName = (om.AssociatedMenuConfiguration.Behavior.Value == AssociatedMenuBehavior.UseLabel) ?
                            om.AssociatedMenuConfiguration.Label.UserLocalizedLabel.Label :
                            entityMetadataCollection.Where(x => x.LogicalName == om.ReferencingEntity).FirstOrDefault().DisplayCollectionName.UserLocalizedLabel.Label;

                        // Set all properties
                        relatedData.ReferencedEntity = om.ReferencedEntity;
                        relatedData.ReferencedAttribute = om.ReferencedAttribute;
                        relatedData.ReferencingEntity = om.ReferencingEntity;
                        relatedData.ReferencingAttribute = om.ReferencingAttribute;
                        relatedData.SchemaName = om.SchemaName;
                        relatedData.ObjectTypeCode = (int)entityMetadataCollection.Where(x => x.LogicalName == relatedData.ReferencingEntity).First().ObjectTypeCode;

                        // Add Mapping information for 1:N
                        var id = (from emp in EntityMaps
                                  join amp in AttributeMaps
                                  on emp.EntityMapId equals amp.EntityMapId
                                  where emp.SourceEntityName == relatedData.ReferencedEntity &&
                                 emp.TargetEntityName == om.ReferencingEntity &&
                                 amp.SourceAttributeName == om.ReferencedAttribute &&
                                 amp.TargetAttributeName == om.ReferencingAttribute
                                  select emp.EntityMapId).FirstOrDefault();
                        relatedData.AttributeMaps = AttributeMaps.Where(x => x.EntityMapId == id).ToList();
                        // Add related Entity information
                        relatedEntities.Add(relatedData);
                    }
                }

                // Do the same for N:N
                List<ManyToManyRelationshipMetadata> mmm = new List<ManyToManyRelationshipMetadata>();
                foreach (var mm in em.ManyToManyRelationships)
                {
                    // Only store available Entities for this app.
                    if (list.Contains((mm.Entity1LogicalName == em.LogicalName) ? mm.Entity2LogicalName : mm.Entity1LogicalName))
                    {
                        // As we don't know if primary entity becomes Referenced/Referencing, checking both and store information in a same manner.
                        mmm.Add(mm);
                        // If primary entity is stored as Entity1
                        if (mm.Entity1LogicalName == em.LogicalName)
                        {
                            // Only Store displayed Entities.
                            if (mm.Entity2AssociatedMenuConfiguration.Behavior.Value == AssociatedMenuBehavior.DoNotDisplay)
                                continue;

                            // Referenced is Entity1
                            RelatedData relatedData = new RelatedData();
                            relatedData.DisplayName = (mm.Entity2AssociatedMenuConfiguration.Behavior.Value == AssociatedMenuBehavior.UseLabel) ?
                                mm.Entity2AssociatedMenuConfiguration.Label.UserLocalizedLabel.Label :
                                entityMetadataCollection.Where(x => x.LogicalName == mm.Entity2LogicalName).FirstOrDefault().DisplayCollectionName.UserLocalizedLabel.Label;
                            relatedData.ReferencedEntity = mm.Entity1LogicalName;
                            relatedData.ReferencedAttribute = mm.Entity1IntersectAttribute;
                            relatedData.ReferencingEntity = mm.Entity2LogicalName;
                            relatedData.ReferencingAttribute = mm.Entity2IntersectAttribute;
                            relatedData.IntersectEntityName = mm.IntersectEntityName;
                            relatedData.SchemaName = mm.SchemaName;
                            relatedData.ObjectTypeCode = (int)entityMetadataCollection.Where(x => x.LogicalName == relatedData.ReferencingEntity).First().ObjectTypeCode;

                            relatedEntities.Add(relatedData);
                        }
                        // If primary entity is stored as Entity2
                        else
                        {
                            // Only Store displayed Entities.
                            if (mm.Entity1AssociatedMenuConfiguration.Behavior.Value == AssociatedMenuBehavior.DoNotDisplay)
                                continue;

                            // Referenced is Entity2
                            RelatedData relatedData = new RelatedData();
                            relatedData.DisplayName = (mm.Entity1AssociatedMenuConfiguration.Behavior.Value == AssociatedMenuBehavior.UseLabel) ?
                                mm.Entity1AssociatedMenuConfiguration.Label.UserLocalizedLabel.Label :
                                entityMetadataCollection.Where(x => x.LogicalName == mm.Entity1LogicalName).FirstOrDefault().DisplayCollectionName.UserLocalizedLabel.Label;
                            relatedData.ReferencedEntity = mm.Entity2LogicalName;
                            relatedData.ReferencedAttribute = mm.Entity2IntersectAttribute;
                            relatedData.ReferencingEntity = mm.Entity1LogicalName;
                            relatedData.ReferencingAttribute = mm.Entity1IntersectAttribute;
                            relatedData.IntersectEntityName = mm.IntersectEntityName;
                            relatedData.SchemaName = mm.SchemaName;
                            relatedData.ObjectTypeCode = (int)entityMetadataCollection.Where(x => x.LogicalName == relatedData.ReferencingEntity).First().ObjectTypeCode;
                            relatedEntities.Add(relatedData);
                        }
                    }
                }

                em.OneToManyRelationships = omm.ToArray();
                em.ManyToManyRelationships = mmm.ToArray();
                EntityMetadataExCollection.Add(new EntityMetadataEx(em, relatedEntities));
            }

            // Now cache it.
            await Util.SaveToLocal(EntityMetadataExCollection, "EntityMetadataExCollection.dat");
        }

        /// <summary>
        /// This method set Application Language by using CRM language
        /// </summary>
        static public void SetAppLanguage()
        {
            // Set UI language by using CRM User settings.
            if (UserSettings.UILanguageId != null && LCIDandTAG.Keys.Contains((int)UserSettings.UILanguageId))
                ApplicationLanguages.PrimaryLanguageOverride = LCIDandTAG[(int)UserSettings.UILanguageId];
            // If no language match, then use English.
            else
                ApplicationLanguages.PrimaryLanguageOverride = "en-US";
        }

        #endregion 

        /// <summary>
        /// Retrieve records by using FetchXML
        /// </summary>
        /// <param name="fetchXml">Retreive record by using FetchXml</param>
        /// <returns>Entity records.</returns>
        static public async System.Threading.Tasks.Task<DataCollection<Entity>> RetrieveByFetchXml(string fetchXml)
        {
            string errorMessage = "";
            try
            {
                // Make sure AccessToken is valid.
                await Util.EnsureToken();

                return (await _proxy.RetrieveMultiple(new FetchExpression(fetchXml))).Entities;
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                // need to handle non-crm error
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }
            return null;
        }

        /// <summary>
        /// Retrieve records and generate data for View by using SavedQuery. This returns 25 - 250 records only depending on UserSettings.PagingLimit.
        /// </summary>
        /// <param name="savedQuery">View information which includs FetchXml and LayoutXml</param>
        /// <param name="relatedData">If this is for related grid, pass RelatedData</param>
        /// <param name="PrimaryFieldName">If this is for lookup grid, pass PrimaryFieldName of the entity so that it can generate EntityReference</param>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task<DataCollection<ViewData>> RetrieveByFetchXmlForView(SavedQuery savedQuery, RelatedData relatedData = null, string PrimaryFieldName = null)
        {
            string errorMessage = "";
            try
            {
                // Make sure AccessToken is valid.
                await Util.EnsureToken();

                // Obtain columns information from LayoutXml
                List<string> cols = new List<string>();
                XDocument layoutXml = XDocument.Parse(savedQuery.LayoutXml);
                foreach (XElement cell in layoutXml.Descendants("cell"))
                {
                    // Store name attribute of each cell.
                    cols.Add(cell.Attribute("name").Value);
                }

                // If this is for lookup and LayoutXml doesn't have PrimaryField, then add it,
                // because lookup needs PrimaryField to display the record.
                if (!string.IsNullOrEmpty(PrimaryFieldName) && !cols.Contains(PrimaryFieldName))
                    cols.Add(PrimaryFieldName);

                // If this is for related grid, then modify the fetchxml to have necessary regarding filter.
                if (relatedData != null)
                    savedQuery.FetchXml = await GenerateRelatedFetchXml(savedQuery, relatedData);

                // Instantiate ViewData list which store fields data for View.
                DataCollection<ViewData> list = new DataCollection<ViewData>();

                // Use pagelimit setting from UserSettings to limit number of records.
                int pageLimit = (int)UserSettings.PagingLimit;

                // Parse FetchXml into XDocument
                XDocument fetchXml = XDocument.Parse(savedQuery.FetchXml);
                // Add count (top) number.
                fetchXml.Element("fetch").Add(new XAttribute("count", pageLimit));

                // Retrieve records by using generated FetchXML
                EntityCollection results = (await _proxy.RetrieveMultiple(new FetchExpression(fetchXml.ToString())));

                // KeyValuePair<string, object> express a field, and List stores a record.
                foreach (var result in results.Entities)
                {
                    List<KeyValuePair<string, object>> record = new List<KeyValuePair<string, object>>();
                    for (int i = 0; i < cols.Count(); i++)
                    {
                        // For each columns, check if there is a data or not.
                        // Try to get formatted value first, then raw data.
                        // col[i] is field's LogicalName
                        object fieldvalue = (result.FormattedValues.Contains(cols[i])) ? result.FormattedValues[cols[i]] :
                            (result.Attributes.Contains(cols[i])) ? result.Attributes[cols[i]] : null;

                        // Add a filed to a record
                        record.Add(new KeyValuePair<string, object>(cols[i], fieldvalue));
                    }

                    // Once stored all the columns(fields), then re-assing to ViewData.
                    // If you want to display more than 3 columns(fields) to view, then modify here.
                    // First column(field)
                    object first = (record.Count() > 0) ? GetValue(record[0].Value, true) : null;
                    // Second column(field)
                    object second = (record.Count() > 1) ? GetValue(record[1].Value, true) : null;
                    // Third column(field)
                    object third = (record.Count() > 2) ? GetValue(record[2].Value, true) : null;
                    // Store ActivityTypeName in case it is Activity view to differenciate each other.
                    string activityTypeName = (savedQuery.ReturnedTypeCode == "activitypointer") ? result.Attributes["activitytypecode"].ToString() : null;
                    // And store primary name field value just in case first three columns(fields) does not have it.
                    string primaryFieldValue = (!string.IsNullOrEmpty(PrimaryFieldName) && result.Contains(PrimaryFieldName)) ? result[PrimaryFieldName].ToString() : null;

                    // create ViewData
                    list.Add(new ViewData(result.Id, first, second, third, activityTypeName, primaryFieldValue));

                    // If you want to cache retrieved data, you can cache it. But this sample always retrieve real-time data.
                }

                return list;
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                // need to handle non-crm error
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }
            return null;
        }
        
        /// <summary>
        /// This method gerenate FetchXml for Related by revising condition. Marked private as this only called from RetrieveByFetchXmlForView
        /// </summary>
        /// <param name="savedQuery">View information which includes FetchXml</param>
        /// <param name="relatedData">Releated Data</param>
        /// <returns></returns>
        static private async System.Threading.Tasks.Task<string> GenerateRelatedFetchXml(SavedQuery savedQuery, RelatedData relatedData)
        {
            string errorMessage = "";
            try
            {
                // Make sure AccessToken is valid.
                await Util.EnsureToken();

                // Though you can directly manipulate fetchxml by using XDocument, as a sample
                // I convert it to QueryExpression first, modify it, then convert back to FetchXml at the end.
                // For real application, you should simply modify FetchXml directly to save server calls.
                QueryExpression qe = (await _proxy.Execute(new FetchXmlToQueryExpressionRequest() { FetchXml = savedQuery.FetchXml })
                    as FetchXmlToQueryExpressionResponse).Query;

                LinkEntity le = null;
                // If this is 1:N relationship (no intersectEntity)
                if (relatedData.IntersectEntityName == null)
                {
                    // Create LinkEntity information
                    LinkEntity linkEntity = new LinkEntity()
                    {
                        // This is a query for related view. For example, if main entity is Account and
                        // you are now trying to retrieve Contacts related to an account record. Therefore
                        // you create query for Contact entity, and filter from Contact to Account.
                        // Referenced is main entity (Account) and Referencing is related entity (Contact)
                        LinkFromEntityName = relatedData.ReferencingEntity, // Contact for this example
                        LinkFromAttributeName = relatedData.ReferencingAttribute, // parentcustomerid for this example
                        LinkToEntityName = relatedData.ReferencedEntity, // Account for this example
                        LinkToAttributeName = relatedData.ReferencedAttribute, // accountid for this example
                        LinkCriteria =
                        {
                            Conditions =
                        {
                            new ConditionExpression(
                                relatedData.ReferencedAttribute, // accountid for this example
                                ConditionOperator.Equal,
                                relatedData.Id) // actual id of main record which is Account for this example.
                        }
                        }
                    };
                    le = linkEntity;
                }
                else // If this is N:N relationship
                {
                    // As this is N:N relationsihp, we need to create 2 LinkEntities and link them together.
                    // First, from Referencing (related entity) to intersect entity by using is primary ids.
                    LinkEntity linkEntity = new LinkEntity()
                    {
                        LinkFromEntityName = relatedData.ReferencingEntity,
                        LinkFromAttributeName = relatedData.ReferencingAttribute,
                        LinkToEntityName = relatedData.IntersectEntityName,
                        LinkToAttributeName = relatedData.IntersectEntityName.ToLower().Substring(0, relatedData.IntersectEntityName.Length - 1) + "id", // intersectEntity's id is always it's IntersectEntityName (without s) + id
                        LinkEntities = 
                    {
                        // Then another LinkEntity from intersect to Referenced (primary entity)
                        new LinkEntity()
                        {
                            LinkFromEntityName = relatedData.IntersectEntityName,
                            LinkFromAttributeName = relatedData.IntersectEntityName.ToLower().Substring(0, relatedData.IntersectEntityName.Length - 1) + "id",
                            LinkToEntityName = relatedData.ReferencedEntity,
                            LinkToAttributeName = relatedData.ReferencedAttribute,        
                            LinkCriteria =
                            {
                                Conditions =
                                {
                                    new ConditionExpression(
                                        relatedData.ReferencedAttribute,
                                        ConditionOperator.Equal,
                                        relatedData.Id)
                                }
                            }
                        }
                    }
                    };
                    le = linkEntity;
                }
                qe.LinkEntities.Add(le);

                // At last, convert QueryExpression to fetchxml.
                return (await _proxy.Execute(new QueryExpressionToFetchXmlRequest() { Query = qe }) as QueryExpressionToFetchXmlResponse).FetchXml;
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                // need to handle non-crm error
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }

            return null;
        }     

        /// <summary>
        /// Retrieve record wrapper. You can change to use REST if you want
        /// </summary>
        /// <param name="entityMetadata">record EntityMetadata</param>
        /// <param name="id">record id</param>
        /// <param name="cols">fields to be retrieved</param>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task<Entity> RetrieveRecord(EntityMetadata entityMetadata, Guid id, ColumnSet cols)
        {
            string errorMessage = "";
            try
            {
                // Make sure AccessToken is valid.
                await Util.EnsureToken();

                return await _proxy.Retrieve(entityMetadata.LogicalName, id, cols);
                // Use below code for REST
                //return await _proxy.RestRetrieve(entityMetadata.SchemaName, id, columnSet);
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                // need to handle non-crm error
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }
            return null;
        }

        /// <summary>
        /// This method return new related record by filling all the auto mapped field data using mapping information and original entity record.  
        /// </summary>
        /// <param name="originalRecord">source record's data</param>
        /// <param name="relatedData">Related Entity information</param>
        /// <param name="entityMetadataEx">original record's EntityMatadata</param>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task<Entity> RetrieveRecordForRelated(Entity originalRecord, RelatedData relatedData, EntityMetadataEx entityMetadataEx)
        {
            string errorMessage = "";
            try
            {
                // Make sure AccessToken is valid.
                await Util.EnsureToken();

                // Create ColumnSet by using mapping information for RelatedData.
                ColumnSet cols = new ColumnSet();
                cols.AddColumns(relatedData.AttributeMaps.Select(x => x.SourceAttributeName).ToArray());
                
                // Then retrieve necessary data from the source record. The reason why you need to retireve 
                //it again is because originalRecord may not have enough data.
                Entity sourceRecord = await _proxy.Retrieve(originalRecord.LogicalName, originalRecord.Id, cols);

                // Create new entity to store values from source record.
                Entity targetRecord = new Entity(relatedData.ReferencingEntity);
                foreach (MyAttributeMap mam in relatedData.AttributeMaps)
                {
                    // If source record has a value for mapping field, then copy it.
                    if (sourceRecord.Attributes.Contains(mam.SourceAttributeName))
                    {
                        //check if the attribute is relationship field.
                        if (mam.TargetAttributeName == relatedData.ReferencingAttribute)
                        {  
                            // If so, create new EntityReference as Lookup value
                            EntityReference Referenced = new EntityReference(originalRecord.LogicalName, originalRecord.Id);
                            Referenced.Name = originalRecord[entityMetadataEx.EntityMetadata.PrimaryNameAttribute].ToString();
                            targetRecord[mam.TargetAttributeName] = Referenced;
                        }
                        else
                            // Otherwise, simply copy it.
                            targetRecord[mam.TargetAttributeName] = sourceRecord.Attributes[mam.SourceAttributeName];
                    }
                }

                // if generated record doesn't have original record reference, then add it.
                if (!targetRecord.Attributes.Contains(relatedData.ReferencingAttribute))
                {
                    EntityReference Referenced = new EntityReference(originalRecord.LogicalName, originalRecord.Id);
                    Referenced.Name = originalRecord[entityMetadataEx.EntityMetadata.PrimaryNameAttribute].ToString();
                    targetRecord[relatedData.ReferencingAttribute] = Referenced;
                }

                // return a record
                return targetRecord;
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                // need to handle non-crm error
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }

            return null;
        }
        
        /// <summary>
        /// Retrieve SavedQueries for Grid as View. If you want to obtain User View, then query UserQuery as well.
        /// </summary>
        /// <param name="entityTypeCode">ObjectTypeCode for the entity</param>
        /// <param name="isRegarding">Mark true when this is for related grid</param>
        /// <param name="isLookup">Mark tru when this is for lookup </param>
        /// <param name="QuickFindSearchCriteria">Pass quickfind search criteria</param>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task<DataCollection<SavedQuery>> RetrieveViews(int entityTypeCode, 
            bool isRegarding = false, bool isLookup = false, string QuickFindSearchCriteria = null)
        {
            string errorMessage = "";
            try
            {
                // Make sure AccessToken is valid.
                await Util.EnsureToken();

                DataCollection<SavedQuery> views = new DataCollection<SavedQuery>();

                // When you have many System Views, retriving views everytime user navigates to grid costs a lot.
                // You should consider cache the result and/or user REST. However, if you cache the view, then 
                // you need to put logic to update it when new view is available.
                // In this sample, generate FetchXML dynamically and retireve it all the time.

                // Create query to retrieve view. Show non-grid view top or, if it is grid view, then show Default view on the top.
                string query = string.Format(@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
  <entity name='savedquery'>
    <attribute name='name' />
    <attribute name='fetchxml' />
    <attribute name='layoutxml' />
    <attribute name='querytype' />
    <attribute name='returnedtypecode' />
    <order attribute='querytype' descending='true' />
    <order attribute='isdefault' descending='true' />
    <filter type='and'>
      <condition attribute='returnedtypecode' operator='eq' value='{0}' />
      <condition attribute='fetchxml' operator='not-null' />
      <filter type='or'>
        <condition attribute='querytype' operator='eq' value='{1}' />
        {2}
        {3}
      </filter>
    </filter>
  </entity>
</fetch>", entityTypeCode.ToString(),
             (string.IsNullOrEmpty(QuickFindSearchCriteria) ? "0" : "4"), // 0: Standard view 4: QuickFined View
             (isRegarding) ? "<condition attribute='querytype' operator='eq' value='2' />" : "", // 2: Associate View
             (isLookup) ? "<condition attribute='querytype' operator='eq' value='64' />" : ""); // 64: Lookup View

                // Now retireve SavedQueries(Views)
                var results = await _proxy.RetrieveMultiple(new FetchExpression(query));

                // If it is quickfind view, then replace search criteria
                if (!string.IsNullOrEmpty(QuickFindSearchCriteria) && results != null)
                {
                    // Replace * to % if there is any.
                    QuickFindSearchCriteria = QuickFindSearchCriteria.Replace('*','%');

                    // There is a QuickFind view for each Entity. Obtain current EntityMetadataEx first.
                    EntityMetadataEx em = EntityMetadataExCollection.Where(x => x.EntityMetadata.ObjectTypeCode == entityTypeCode).First();
                    // Get SavedQuery. There is only 1 result for this.
                    SavedQuery result = results[0] as SavedQuery;
      
                    // Replace place holder to QuickFindSearchCriteria
                    // First parse FetchXML to XDocument by replacing placeholder to SerchCriteria
                    XDocument xdoc = XDocument.Parse(string.Format(result.FetchXml, QuickFindSearchCriteria));

                    // Check if there are any lookup fields as part of Search Columns. If there is any, then need to treat them separately.
                    // Instantiate List to store Conditions to add
                    List<XElement> conditionList = new List<XElement>();
                    // look all filter node
                    foreach (var filter in xdoc.Descendants("filter"))
                    {
                        // if it is not for QuickFind, do nothing.
                        if (filter.Attribute("isquickfindfields") == null)
                            continue;

                        // if it is for QuickFind
                        foreach (var item in filter.Elements())
                        {
                            // Obtain AttributeMetadata to see if this is lookup or not.
                            // If this is lookup, then we cannot simply replace query condition as it requires Guid(s).
                            AttributeMetadata am = em.EntityMetadata.Attributes.Where(x => x.LogicalName == item.Attribute("attribute").Value).First();
                            // if condition has lookup in it (like Parent Account), needs to query it first to obtain Guids
                            if (am.AttributeType == AttributeTypeCode.Lookup || am.AttributeType == AttributeTypeCode.Customer || am.AttributeType == AttributeTypeCode.Owner)
                            {
                                LookupAttributeMetadata lam = am as LookupAttributeMetadata;
                                foreach (var target in lam.Targets)
                                {
                                    // Create Query for looked up entity
                                    EntityMetadata targetem = EntityMetadataExCollection.Where(x => x.EntityMetadata.LogicalName == target).First().EntityMetadata;
                                    QueryExpression qe = new QueryExpression();
                                    qe.EntityName = target;
                                    qe.ColumnSet = new ColumnSet(targetem.PrimaryNameAttribute);
                                    qe.Criteria = new FilterExpression()
                                    {
                                        Conditions = 
                                        {
                                            new ConditionExpression
                                            {
                                                // Use Search Criteria to find records
                                                AttributeName = targetem.PrimaryNameAttribute,
                                                Operator=ConditionOperator.BeginsWith,
                                                Values={QuickFindSearchCriteria}
                                            }
                                        }
                                    };

                                    // Retrieve results
                                    var targetresults = await _proxy.RetrieveMultiple(qe);
                                    // Replace Condition to exact match, as it filters by using record Guids
                                    foreach (var targetresult in targetresults.Entities)
                                    {
                                        // As we don't know how many records are returned from the query, store them for replacement later.
                                        conditionList.Add(XElement.Parse(item.ToString().Replace("like", "eq").Replace(QuickFindSearchCriteria, targetresult.Id.ToString())));
                                    }
                                }
                                // First, remove the placeholder
                                item.Remove();
                                // Then add new condition(s).
                                filter.Add(conditionList.ToArray());
                            }
                        }
                    }

                    // Finally return the result
                    result.FetchXml = xdoc.ToString();
                    views.Add(result);
                }
                else
                {
                    // If not QuickFind, then just passes the view data.
                    foreach (SavedQuery result in results.Entities)
                    {
                        views.Add(result);
                    }
                }

                // If you want to combine User View as well, then you need to do it.

                return views;
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                // need to handle non-crm error
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }

            return null;
        }
        
        /// <summary>
        /// Retrieve fields information for a form. Returned data also include composit fields 
        /// (address and fullname) and PrimaryName field as well, even if mobile form doesn't have it.
        /// </summary>
        /// <param name="entityMetadataEx">EntityMetadata of entity which you want to retrieve a form</param>
        /// <param name="fieldnames">Specify fields which you want to use for the form. If nothing speficied, it uses Mobile form definition.</param>
        /// <returns>form data</returns>
        static public async System.Threading.Tasks.Task<List<FormFieldData>> RetrieveFormFields(EntityMetadataEx entityMetadataEx, List<string> fieldnames = null)
        {   
            string errorMessage = "";
            try
            {
                List<FormFieldData> fields;
                // Try to restore from cache
                fields = (List<FormFieldData>)await Util.ReadFromLocal<List<FormFieldData>>("fieldsFor" + entityMetadataEx.EntityMetadata.LogicalName + "dat");

                if (fields != null)
                    return fields;

                // if no cache, then create new instance.
                fields = new List<FormFieldData>();

                // If no fields passed, then try to get from mobile form
                if (fieldnames == null)
                    fieldnames = (List<string>)await Util.ReadFromLocal<List<string>>("MobileFormfieldsFor" + entityMetadataEx.EntityMetadata.LogicalName + "dat");

                // if no mobile form cache, then retireve it.
                if(fieldnames == null)
                {
                    // creaet new instance
                    fieldnames = new List<string>();
                 
                    DataCollection<SystemForm> systemForms = new DataCollection<SystemForm>();
                    // Retrieve Mobile Form. if you want to use different fields set, change the query here.
                    // type=5 is mobile form
                    string query = string.Format(@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
  <entity name='systemform'>
    <attribute name='name' />
    <attribute name='formxml' />
      <filter type='and'>
      <condition attribute='objecttypecode' operator='eq' value='{0}' />
      <condition attribute='type' operator='eq' value='5' />
    </filter>
  </entity>
</fetch>", entityMetadataEx.EntityMetadata.ObjectTypeCode.ToString());

                    // Make sure AccessToken is valid.
                    await Util.EnsureToken();

                    // There should be more than a mobile form all the time, but we may want to do null check first in real scenario
                    SystemForm systemForm = (SystemForm)(await _proxy.RetrieveMultiple(new FetchExpression(query))).Entities[0];

                    // Parse the form to get fieldnames.
                    XDocument formXml = XDocument.Parse(systemForm.FormXml);

                    // loop through cell nodes
                    foreach (XElement cell in formXml.Descendants("cell"))
                    {
                        // check if the cell has necessary data. 
                        if (cell.Element("control") == null || cell.Element("control").Attribute("datafieldname") == null)
                            continue;

                        fieldnames.Add(cell.Element("control").Attribute("datafieldname").Value);
                    }

                    // cache it
                    await Util.SaveToLocal(fieldnames, "MobileFormfieldsFor" + entityMetadataEx.EntityMetadata.LogicalName + "dat");                
                }

                // check if additional fields already included.
                bool primaryFieldExists = false;
                bool address1FieldExists = false;
                bool address2FieldExists = false;
                bool compositAddress1Exists = false;
                bool compositAddress2Exists = false;
                bool statusFieldExists = false;

                // loop through all fields
                foreach (string fieldname in fieldnames)
                {
                    FormFieldData fieldData = new FormFieldData();

                    // Try to store its AttributeMetadata 
                    AttributeMetadata attributeMeatdata = entityMetadataEx.EntityMetadata.Attributes.
                            Where(x => x.LogicalName == fieldname).FirstOrDefault();

                    // If no matching AttributeMetadata, then go to next cell.
                    if (attributeMeatdata == null)
                        continue;
                    
                    // Store the AttributeMetadata
                    fieldData.FieldMetadata = attributeMeatdata;

                    // if this field is PrimrayNameAttribute, mark it so we don't need to retrieve it later.
                    if (fieldData.FieldMetadata.LogicalName == entityMetadataEx.EntityMetadata.PrimaryNameAttribute)
                        primaryFieldExists = true;
                    // if this field is composit field for address 1, mark it so we don't need to retrieve it later.
                    else if (fieldData.FieldMetadata.LogicalName == "address1_composite")
                        compositAddress1Exists = true;
                    // if this field is composit field for address 2, mark it so we don't need to retrieve it later.
                    else if (fieldData.FieldMetadata.LogicalName == "address2_composite")
                        compositAddress2Exists = true;
                    // if this field is any of address 1, then mark it true so that we may need to retrieve conposit conrol later
                    else if (fieldData.FieldMetadata.LogicalName.Contains("address1"))
                        address1FieldExists = true;
                    // if this field is any of address 2, then mark it true so that we may need to retrieve conposit conrol later
                    else if (fieldData.FieldMetadata.LogicalName.Contains("address2"))
                        address2FieldExists = true;
                    else if (fieldData.FieldMetadata.LogicalName == "statecode")
                        statusFieldExists = true;

                    fields.Add(fieldData);
                }

                // if primary field does not included, then retrieve it.
                if (!primaryFieldExists)
                {
                    var primaryNameMeta = entityMetadataEx.EntityMetadata.Attributes.Where(x => x.LogicalName == entityMetadataEx.EntityMetadata.PrimaryNameAttribute).FirstOrDefault();
                    if (primaryNameMeta != null)
                        fields.Add(new FormFieldData(primaryNameMeta));
                }
                // if composit field is not exist when address field exist, then retrieve composite
                if (address1FieldExists && !compositAddress1Exists)
                {
                    var address1Meta = entityMetadataEx.EntityMetadata.Attributes.Where(x => x.LogicalName == "address1_composite").FirstOrDefault();
                    if (address1Meta != null)
                        fields.Add(new FormFieldData(address1Meta));
                }
                // if composit field is not exist when address field exist, then retrieve composite
                if (address2FieldExists && !compositAddress2Exists)
                {
                    var address2Meta = entityMetadataEx.EntityMetadata.Attributes.Where(x => x.LogicalName == "address2_composite").FirstOrDefault();
                    if (address2Meta != null)
                        fields.Add(new FormFieldData(address2Meta));
                }
                // if image is enabled for entity, then retrieve it 
                if (!string.IsNullOrEmpty(entityMetadataEx.EntityMetadata.PrimaryImageAttribute))
                {
                    var primaryImageMeta = 
                        entityMetadataEx.EntityMetadata.Attributes.Where(x => x.LogicalName == entityMetadataEx.EntityMetadata.PrimaryImageAttribute).FirstOrDefault();
                    if (primaryImageMeta != null)
                        fields.Add(new FormFieldData(primaryImageMeta));
                }
                // if records does not include statecode, then retrieve it.
                if (!statusFieldExists)
                {
                    var statecodeMeta = entityMetadataEx.EntityMetadata.Attributes.Where(x => x.LogicalName == "statecode").FirstOrDefault();
                    if (statecodeMeta != null)
                        fields.Add(new FormFieldData(statecodeMeta));
                }

                // Cache the fields 
                await Util.SaveToLocal(fields, "fieldsFor" + entityMetadataEx.EntityMetadata.LogicalName + "dat");

                return fields;
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                // need to handle non-crm error
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }

            return null;
        }

        /// <summary>
        /// Returns string value for display
        /// </summary>
        /// <param name="content">object to display</param>
        /// <param name="isForView">This is used for ActivityParty class, as it may have
        /// many records in it. For view, just keep adding text information as one field. </param>
        /// <returns></returns>
        static public object GetValue(object content, bool isForView = false) 
        {
            if (content == null)
                return null;
            switch (content.GetType().Name)
            {
                case "AliasedValue":
                    return ((AliasedValue)content).Value;
                case "EntityReference":
                    return ((EntityReference)content).Name;
                case "OptionSetValue":
                    return ((OptionSetValue)content).Value;
                case "Money":
                    return ((Money)content).Value;
                case "EntityCollection":
                    //Assume it is activity party
                    if (((EntityCollection)content).Entities.Count() == 0)
                        return "";
                    DataCollection<ActivityParty> list = new DataCollection<ActivityParty>();
                    string stringForView = "";
                    foreach (Entity item in ((EntityCollection)content).Entities)
                    {
                        if (isForView)
                            stringForView += ((ActivityParty)item).PartyId.Name + ", ";
                        else
                            list.Add((ActivityParty)item);
                    }
                    if (isForView)
                        return stringForView.Substring(0, stringForView.Length - 2);
                    else
                        return list.ToArray();
                default:
                   return content;
            }            
        }

        /// <summary>
        /// Retrieve a record.
        /// </summary>
        /// <param name="record">record to be deleted</param>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task<Entity> RetrieveRecord(string entityLogicalName, Guid id, ColumnSet columnSet)
        {
            string errorMessage = "";
            Entity result = null;
            try
            {
                // Make sure AccessToken is valid.
                await Util.EnsureToken();

                result = await _proxy.Retrieve(entityLogicalName, id, columnSet);
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                // need to handle non-crm error
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }
            return result;
        }

        /// <summary>
        /// Do update/insert. You can change here to use REST endpoint instead.
        /// </summary>
        /// <param name="record">record for update/insert</param>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task<Entity> UpsertRecord(Entity record)
        {
            string errorMessage = "";
            try
            {
                // Make sure AccessToken is valid.
                await Util.EnsureToken();

                // if there is no id, then this should be created.
                if (record.Id == Guid.Empty)
                {
                    Guid id = await _proxy.Create(record);
                    //Guid id = await _proxy.RestCreate(record);
                    return await _proxy.Retrieve(record.LogicalName, id, new ColumnSet(true));
                }
                // otherwise update.
                else
                {
                    await _proxy.Update(record);
                    //await _proxy.RestUpdate(record);
                    //return record;
                    return record;
                }
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                // need to handle non-crm error
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }
            return null;
        }

        /// <summary>
        /// Delete a record. As Entity does not have schemana, you cannot use RESE easily here.
        /// </summary>
        /// <param name="record">record to be deleted</param>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task DeleteRecord(Entity record)
        {
            string errorMessage = "";
            try
            {
                // Make sure AccessToken is valid.
                await Util.EnsureToken();

                await _proxy.Delete(record.LogicalName, record.Id);                
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch(Exception ex)
            {
                // need to handle non-crm error
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }
        }

        /// <summary>
        /// Associate a record. 
        /// </summary>
        /// <param name="record">record to be deleted</param>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task Associate(string entityName, Guid entityId, Relationship relationship,
            EntityReferenceCollection relatedEntities)
        {
            string errorMessage = "";
            try
            {
                // Make sure AccessToken is valid.
                await Util.EnsureToken();

                await _proxy.Associate(entityName, entityId, relationship, relatedEntities);
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                // need to handle non-crm error
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }
        }

        /// <summary>
        /// Associate a record. 
        /// </summary>
        /// <param name="record">record to be deleted</param>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task Disassociate(string entityName, Guid entityId, Relationship relationship,
            EntityReferenceCollection relatedEntities)
        {
            string errorMessage = "";
            try
            {
                // Make sure AccessToken is valid.
                await Util.EnsureToken();

                await _proxy.Disassociate(entityName, entityId, relationship, relatedEntities);
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                // need to handle non-crm error
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }
        }

        /// <summary>
        /// Sending email. 
        /// </summary>
        /// <param name="record">record to be deleted</param>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task SendEmail(Guid recordId)
        {
            string errorMessage = "";
            try
            {
                // Make sure AccessToken is valid.
                await Util.EnsureToken();

                // Send the email
                SendEmailRequest sendEmailRequest = new SendEmailRequest
                {
                    EmailId = recordId,
                    TrackingToken = "",
                    IssueSend = true
                };

                SendEmailResponse sendEmailResponse = (SendEmailResponse)await CRMHelper._proxy.Execute(sendEmailRequest);
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                // need to handle non-crm error
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }
        }

        /// <summary>
        /// This method check user privilege
        /// </summary>
        /// <param name="entityName">Entity name for check</param>
        /// <param name="privilegeType">Privilege type for check</param>
        /// <param name="privilegeDepth">Privilege depth for check</param>
        /// <returns></returns>
        static public bool CheckPrivilege(string entityName, PrivilegeType privilegeType, PrivilegeDepth privilegeDepth)
        {
            // Change entityName to match Privilege name
            if (entityName.ToLower() == "annotation")
                entityName = "Note";
            else if (entityName.ToLower() == "systemuser")
                entityName = "User";

            // Check privilege by using lowername in case entityName is logical name.
            UserPrivilege userPrivilege = userPrivileges.Where(x => x.PrivilegeName.ToLower() == "prv" + privilegeType.ToString().ToLower() + entityName.ToLower()).FirstOrDefault();
            return (userPrivilege != null && userPrivilege.RolePrivilege.Depth >= privilegeDepth);
        }

        /// <summary>
        /// Retrieve note records for a specified record
        /// </summary>
        /// <param name="objectId"> original record id</param>
        /// <param name="objectTypeCode">original record objecttypecode</param>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task<DataCollection<Annotation>> RetrieveNotes(Guid objectId, int objectTypeCode)
        {
            string errorMessage = "";
            try
            {
                string query = String.Format(@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
  <entity name='annotation'>
    <attribute name='subject' />
    <attribute name='notetext' />
    <attribute name='filename' />
    <attribute name='filesize' />
    <attribute name='annotationid' />
    <attribute name='createdon' />
    <order attribute='createdon' descending='true' />
    <filter type='and'>
      <condition attribute='objecttypecode' operator='eq' value='{0}' />
      <condition attribute='objectid' operator='eq' value='{1}' />
    </filter>
  </entity>
</fetch>", objectTypeCode.ToString(), objectId.ToString());

                DataCollection<Annotation> notes = new DataCollection<Annotation>();
                foreach (Annotation result in await RetrieveByFetchXml(query))
                {
                    notes.Add(result);
                }

                return notes;
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                // need to handle non-crm error
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }
            return null;
        }

        #region Xamarin Imcomaptible UI related methods

        /// <summary>
        /// Generate a field by using Attribute Metadata. The issue of this method is that it has UI element, so this is not
        /// really a buginess logic. maybe okay for Universal app, but not for Xamarin
        /// </summary>
        /// <param name="field">Field object, which has field data and metadata</param>
        /// <param name="isUpdate">True when you need a field for update. False when it is for New record form.</param>
        /// <returns></returns>
        static public Grid GenerateField(FormFieldData field, bool isUpdate = true)
        {
            // Check the device width. You many need to change this if you want to use larger display and put it in a grid.
            var w = Window.Current.Bounds.Width;

            // If this is for update and it is composite control (address and fullname), then do nothing as they are not for create/modify
            if (field.FieldMetadata.LogicalName == "address1_composite" || field.FieldMetadata.LogicalName == "address2_composite" || field.FieldMetadata.LogicalName == "fullname")
                return null;

            // For Xamarin, you need to consider how to generate UI items.
            Grid grid = new Grid();
            grid.Width = w - 36;
            // For field name
            grid.RowDefinitions.Add(new RowDefinition());
            // For field value
            grid.RowDefinitions.Add(new RowDefinition());

            // Create stackpanel to hold field name as well as required informaiton.
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;

            // Requirement information (display by using [*] and color)
            TextBlock required = new TextBlock();
            required.Text = "*";
            required.Style = (Style)Application.Current.Resources["BodyTextBlockStyle"];
            // Required is displayed in Red, Recommended in Blue.
            if (((AttributeMetadata)field.FieldMetadata).RequiredLevel.Value == AttributeRequiredLevel.SystemRequired || ((AttributeMetadata)field.FieldMetadata).RequiredLevel.Value == AttributeRequiredLevel.ApplicationRequired)
                required.Foreground = new SolidColorBrush(Colors.Red);
            else if (((AttributeMetadata)field.FieldMetadata).RequiredLevel.Value == AttributeRequiredLevel.Recommended)
                required.Foreground = new SolidColorBrush(Colors.Blue);
            else
                required.Text = "";
            sp.Children.Add(required);

            // Field Name
            TextBlock label = new TextBlock();
            label.Name = "lbl" + field.FieldMetadata.LogicalName;
            label.Text = field.FieldMetadata.DisplayName.UserLocalizedLabel.Label + ": ";
            label.Style = (Style)Application.Current.Resources["BodyTextBlockStyle"];
            label.TextWrapping = TextWrapping.Wrap;

            sp.Children.Add(label);

            grid.Children.Add(sp);
            Grid.SetRow(sp, 0);

            // Binding field data.
            grid.DataContext = field;
            Binding binding = new Binding();
            binding.Path = new PropertyPath("FieldData");
            binding.Mode = BindingMode.TwoWay;

            // Check the field type
            switch (field.FieldMetadata.GetType().Name)
            {
                case "BooleanAttributeMetadata":
                    {
                        BooleanAttributeMetadata meta = (BooleanAttributeMetadata)field.FieldMetadata;

                        // Use custom control, which hides checkbox and display combobox instead.
                        CheckBoxEx checkBoxEx = new CheckBoxEx(meta.OptionSet.TrueOption.Label.UserLocalizedLabel.Label, meta.OptionSet.FalseOption.Label.UserLocalizedLabel.Label);

                        checkBoxEx.checkBox.DataContext = field;
                        checkBoxEx.checkBox.SetBinding(CheckBox.IsCheckedProperty, binding);
                        // Set the value from record for update or default value for new record
                        if (isUpdate && field.FieldData != null)
                            checkBoxEx.checkBox.IsChecked = (bool)field.FieldData;
                        else if (!isUpdate)
                            checkBoxEx.checkBox.IsChecked = (bool)meta.DefaultValue;

                        grid.Children.Add(checkBoxEx);
                        Grid.SetRow(checkBoxEx, 1);
                    }
                    break;
                case "DateTimeAttributeMetadata":
                    {
                        DateTimeAttributeMetadata meta = (DateTimeAttributeMetadata)field.FieldMetadata;

                        // Use Custom DateTime Control
                        DateTimeControl dateTimeControl = new DateTimeControl(meta);

                        dateTimeControl.DataContext = field;
                        dateTimeControl.SetBinding(DateTimeControl.DataContextProperty, binding);

                        // Get the DateTime from record or set to current time for new record
                        if (isUpdate && field.FieldData != null)
                            dateTimeControl.Date = (DateTime)field.FieldData;
                        else if (!isUpdate)
                            dateTimeControl.Date = DateTime.Now;

                        ////dateTimeControl.DataContext = defaultValue;
                        //dateTimeControl.Date = defaultValue;

                        grid.Children.Add(dateTimeControl);
                        Grid.SetRow(dateTimeControl, 1);
                    }
                    break;
                case "DecimalAttributeMetadata":
                    {
                        DecimalAttributeMetadata meta = (DecimalAttributeMetadata)field.FieldMetadata;

                        // Use contom control for numbers
                        NumberBox<decimal> numberBox = new NumberBox<decimal>();
                        numberBox.Precision = (int)meta.Precision;
                        numberBox.MinValue = (meta.MinValue.HasValue) ? (decimal)meta.MinValue : decimal.MinValue;
                        numberBox.MaxValue = (meta.MaxValue.HasValue) ? (decimal)meta.MaxValue : decimal.MaxValue;
                        numberBox.DataContext = field;
                        numberBox.SetBinding(NumberBox<decimal>.TextProperty, binding);

                        grid.Children.Add(numberBox);
                        Grid.SetRow(numberBox, 1);
                    }
                    break;
                case "DoubleAttributeMetadata":
                    {
                        DoubleAttributeMetadata meta = (DoubleAttributeMetadata)field.FieldMetadata;

                        // Use contom control for numbers
                        NumberBox<double> numberBox = new NumberBox<double>();
                        numberBox.Precision = (int)meta.Precision;
                        numberBox.MinValue = (meta.MinValue.HasValue) ? (double)meta.MinValue : double.MinValue;
                        numberBox.MaxValue = (meta.MaxValue.HasValue) ? (double)meta.MaxValue : double.MaxValue;
                        numberBox.DataContext = field;
                        numberBox.SetBinding(NumberBox<double>.TextProperty, binding);

                        grid.Children.Add(numberBox);
                        Grid.SetRow(numberBox, 1);
                    }
                    break;
                case "EntityNameAttributeMetadata":
                    {
                        EntityNameAttributeMetadata meta = (EntityNameAttributeMetadata)field.FieldMetadata;
                    }
                    break;
                case "ImageAttributeMetadata":
                    {
                        ImageAttributeMetadata meta = (ImageAttributeMetadata)field.FieldMetadata;

                        EntityImageControl entityImage = new EntityImageControl();
                        entityImage.ImageBytes = field.FieldData as byte[];

                        grid.Children.Add(entityImage);
                        Grid.SetRow(entityImage, 1);
                    }
                    break;
                case "IntegerAttributeMetadata":
                    {
                        IntegerAttributeMetadata meta = (IntegerAttributeMetadata)field.FieldMetadata;

                        // Use contom control for numbers
                        NumberBox<int> numberBox = new NumberBox<int>();
                        numberBox.Precision = 0;
                        numberBox.MinValue = (meta.MinValue.HasValue) ? (int)meta.MinValue : int.MinValue;
                        numberBox.MaxValue = (meta.MaxValue.HasValue) ? (int)meta.MaxValue : int.MaxValue;
                        numberBox.DataContext = field;
                        numberBox.SetBinding(NumberBox<int>.TextProperty, binding);

                        grid.Children.Add(numberBox);
                        Grid.SetRow(numberBox, 1);
                    }
                    break;
                case "BigIntAttributeMetadata":
                    {
                        BigIntAttributeMetadata meta = (BigIntAttributeMetadata)field.FieldMetadata;

                        // Use contom control for numbers
                        NumberBox<Int64> numberBox = new NumberBox<Int64>();
                        numberBox.Precision = 0;
                        numberBox.MinValue = (meta.MinValue.HasValue) ? (Int64)meta.MinValue : Int64.MinValue;
                        numberBox.MaxValue = (meta.MaxValue.HasValue) ? (Int64)meta.MaxValue : Int64.MaxValue;
                        numberBox.DataContext = field;
                        numberBox.SetBinding(NumberBox<Int64>.TextProperty, binding);

                        grid.Children.Add(numberBox);
                        Grid.SetRow(numberBox, 1);
                    }
                    break;
                case "LookupAttributeMetadata":
                    {
                        LookupAttributeMetadata meta = (LookupAttributeMetadata)field.FieldMetadata;

                        if (field.FieldMetadata.AttributeType == AttributeTypeCode.PartyList)
                        {
                            // Use custom lookup control
                            ActivityPartyLookupControl lookup = new ActivityPartyLookupControl();
                            // If there is on data, then assign new EntityCollection
                            if (field.FieldData == null)
                                field.FieldData = new EntityCollection();
                            lookup.Records = field.FieldData as EntityCollection;
                            grid.Children.Add(lookup);
                            Grid.SetRow(lookup, 1);
                        }
                        else
                        {
                            // Use custom lookup control
                            LookupControl lookup = new LookupControl();

                            grid.Children.Add(lookup);
                            Grid.SetRow(lookup, 1);
                        }

                    }
                    break;
                case "MemoAttributeMetadata":
                    {
                        MemoAttributeMetadata meta = (MemoAttributeMetadata)field.FieldMetadata;

                        TextBox textBox = new TextBox();
                        textBox.SetBinding(TextBox.TextProperty, binding);
                        // As it is multiline text, make it TextWrapping to Wrap
                        textBox.TextWrapping = TextWrapping.Wrap;
                        textBox.MaxLength = (meta.MaxLength == null) ? 2000 : (int)meta.MaxLength;
                        textBox.AcceptsReturn = true;
                        if (field.FieldData != null)
                        {
                            textBox.Text = field.FieldData.ToString();
                        }

                        grid.Children.Add(textBox);
                        Grid.SetRow(textBox, 1);
                    }
                    break;
                case "MoneyAttributeMetadata":
                    {
                        MoneyAttributeMetadata meta = (MoneyAttributeMetadata)field.FieldMetadata;

                        // Use contom control for numbers
                        NumberBox<decimal> numberBox = new NumberBox<decimal>();
                        numberBox.Precision = (int)meta.Precision;
                        numberBox.MinValue = (meta.MinValue.HasValue) ? (decimal)meta.MinValue : decimal.MinValue;
                        numberBox.MaxValue = (meta.MaxValue.HasValue) ? (decimal)meta.MaxValue : decimal.MaxValue;
                        numberBox.AttributeMetadata = meta;
                        binding.Path = new PropertyPath("FieldData.Value");
                        numberBox.SetBinding(NumberBox<decimal>.TextProperty, binding);

                        grid.Children.Add(numberBox);
                        Grid.SetRow(numberBox, 1);
                    }
                    break;
                case "PicklistAttributeMetadata":
                    {
                        PicklistAttributeMetadata meta = (PicklistAttributeMetadata)field.FieldMetadata;

                        // Use custom picklist control and pass OptionSet data.
                        PicklistControl picklist = new PicklistControl(meta.OptionSet);

                        // Set the value to contorl
                        if (isUpdate && field.FieldData != null)
                            picklist.SelectedIndex = picklist.Items.IndexOf(meta.OptionSet.Options.Where(x => x.Value == ((OptionSetValue)field.FieldData).Value).First());
                        // If this is not update, then set defualt value
                        else if (!isUpdate && meta.DefaultFormValue != -1)
                            picklist.SelectedItem = picklist.Items.IndexOf(meta.OptionSet.Options.Where(x => x.Value == meta.DefaultFormValue).First());
                        else
                            picklist.SelectedIndex = -1;

                        grid.Children.Add(picklist);
                        Grid.SetRow(picklist, 1);
                    }
                    break;
                case "StateAttributeMetadata":
                    {
                        StateAttributeMetadata meta = (StateAttributeMetadata)field.FieldMetadata;

                        // Use custom picklist control and pass OptionSet data.
                        PicklistControl picklist = new PicklistControl(meta.OptionSet);

                        // Set the value to contorl
                        if (isUpdate && field.FieldData != null)
                            picklist.SelectedIndex = picklist.Items.IndexOf(meta.OptionSet.Options.Where(x => x.Value == ((OptionSetValue)field.FieldData).Value).First());
                        else if (!isUpdate)
                            picklist.SelectedIndex = (meta.DefaultFormValue == null || (int)meta.DefaultFormValue == -1) ? 0 : (int)meta.DefaultFormValue;

                        grid.Children.Add(picklist);
                        Grid.SetRow(picklist, 1);
                    }
                    break;
                case "StatusAttributeMetadata":
                    {
                        StatusAttributeMetadata meta = (StatusAttributeMetadata)field.FieldMetadata;

                        // Use custom picklist control and pass OptionSet data.
                        PicklistControl picklist = new PicklistControl(meta.OptionSet);

                        // Set the value to contorl
                        if (isUpdate && field.FieldData != null)
                            picklist.SelectedIndex = picklist.Items.IndexOf(meta.OptionSet.Options.Where(x => x.Value == ((OptionSetValue)field.FieldData).Value).First());
                        else if (!isUpdate)
                            picklist.SelectedIndex = (meta.DefaultFormValue == null || (int)meta.DefaultFormValue == -1) ? 0 : (int)meta.DefaultFormValue;

                        grid.Children.Add(picklist);
                        Grid.SetRow(picklist, 1);
                    }
                    break;
                case "StringAttributeMetadata":
                    {
                        StringAttributeMetadata meta = (StringAttributeMetadata)field.FieldMetadata;

                        TextBoxEx textBoxEx = new TextBoxEx(meta);
                        textBoxEx.SetBinding(TextBox.TextProperty, binding);
                        textBoxEx.TextWrapping = TextWrapping.Wrap;

                        // As metadata cannot tell if the field is postal or not from metadata,
                        // I need to control this by using actual field name.
                        if (field.FieldMetadata.LogicalName.Contains("postal"))
                            textBoxEx.InputScope = new InputScope() { Names = { new InputScopeName(InputScopeNameValue.TelephoneNumber) } };

                        grid.Children.Add(textBoxEx);

                        Grid.SetRow(textBoxEx, 1);
                    }
                    break;
                case "ManagedPropertyAttributeMetadata":
                    {
                        ManagedPropertyAttributeMetadata meta = (ManagedPropertyAttributeMetadata)field.FieldMetadata;
                    }
                    break;
                default:
                    {
                        AttributeMetadata meta = (AttributeMetadata)field.FieldMetadata;
                    }
                    break;
            }

            return grid;
        }

        /// <summary>
        /// Handle CRM field click event for CRMRecordDetail custom control. As this is UI and page navigation, i may need to 
        /// put this in each project side, not in shared code. For now, I leave this here..
        /// You can modify this method to change the behavior when use click the field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static public async void lvFields_ItemClick(object sender, ItemClickEventArgs e)
        {
            // As this is utility class, not on a page, obtain Frame first
            Frame rootFrame = Window.Current.Content as Frame;
            // Then get the field data.
            var item = e.ClickedItem as StackPanel;
            FormFieldData field = item.DataContext as FormFieldData;

            // if it's image field, then do nothing.
            if (field.FieldMetadata.LogicalName == "entityimage")
            {
                return;
            }
            // check field type. I am using class id here, but i may use metadata instead.
            switch (field.FieldMetadata.AttributeType)
            {
                case AttributeTypeCode.Lookup:
                case AttributeTypeCode.Customer:
                case AttributeTypeCode.Owner:
                    EntityMetadataEx entityMetadataEx = CRMHelper.EntityMetadataExCollection.Where(x => x.EntityMetadata.LogicalName == ((EntityReference)field.FieldData).LogicalName).FirstOrDefault();
                    if (entityMetadataEx == null)
                        return;
                    // Put temporary data for RecordDetailPage
                    CRMHelper.temporaryData = new object[] { ((EntityReference)field.FieldData).Id, entityMetadataEx };
                    rootFrame.Navigate(typeof(RecordDetailPage));
                    return;
                case AttributeTypeCode.Memo:
                    if (field.FieldMetadata.LogicalName.Contains("address") && field.FieldMetadata.LogicalName.Contains("composite"))
                        await Launcher.LaunchUriAsync(new Uri("bingmaps:?where=" + field.FieldData));
                    return;
                case AttributeTypeCode.String:
                    switch (((StringAttributeMetadata)field.FieldMetadata).FormatName.Value)
                    {
                        case "Email":
                            EntityMetadataEx emailme = CRMHelper.EntityMetadataExCollection.Where(x => x.EntityMetadata.LogicalName == "email").FirstOrDefault();
                            if (emailme == null)
                            {
                                // This launch Mail App like Outlook
                                await Launcher.LaunchUriAsync(new Uri("mailto:?to=" + field.FieldData + "&subject=" + "Subject"));
                            }
                            // If this app has email entity, then launch email new form.
                            else
                            {
                                // Obtain Source Record and Metadata
                                Entity record = (((sender as ListView).Parent as Grid).Parent as CRMRecordDetail).Record;
                                EntityMetadataEx em = (((sender as ListView).Parent as Grid).Parent as CRMRecordDetail).EntityMetadataEx;
                                // Instantiate new Fields List
                                List<FormFieldData> fields = new List<FormFieldData>();

                                // Create From 
                                AttributeMetadata from = emailme.EntityMetadata.Attributes.Where(x => x.LogicalName == "from").First();
                                // Instantiate FormFieldData and assign AttributeMetadata
                                FormFieldData fromFieldData = new FormFieldData(from);
                                // Then create data from current user.
                                EntityReference fromReference = CRMHelper.UserInfo.ToEntityReference();
                                // Add FieldData
                                fromFieldData.FieldData = new EntityCollection() { Entities = new DataCollection<Entity>() { new ActivityParty() { PartyId = fromReference } } };
                                // Finally add "from" to fields.
                                fields.Add(fromFieldData);

                                // Create To
                                // Retrieve AttributeMetadata for "to"
                                AttributeMetadata to = emailme.EntityMetadata.Attributes.Where(x => x.LogicalName == "to").First();
                                // Instantiate FormFieldData and assign AttributeMetadata
                                FormFieldData toFieldData = new FormFieldData(to);
                                // Then create data from current record.
                                EntityReference toReference = record.ToEntityReference();
                                // To display name, assign name to EntityReference
                                toReference.Name = record[em.EntityMetadata.PrimaryNameAttribute].ToString();
                                // Add FieldData
                                toFieldData.FieldData = new EntityCollection() { Entities = new DataCollection<Entity>() { new ActivityParty() { PartyId = toReference } } };
                                // Finally add "to" to fields.
                                fields.Add(toFieldData);

                                // Create Cc
                                AttributeMetadata cc = emailme.EntityMetadata.Attributes.Where(x => x.LogicalName == "cc").First();
                                fields.Add(new FormFieldData(cc));

                                // Create Subject
                                AttributeMetadata subject = emailme.EntityMetadata.Attributes.Where(x => x.LogicalName == "subject").First();
                                // If you want to give default subject, assign it here.
                                fields.Add(new FormFieldData(subject));

                                // Create Description
                                AttributeMetadata description = emailme.EntityMetadata.Attributes.Where(x => x.LogicalName == "description").First();
                                fields.Add(new FormFieldData(description));

                                // Create Regarding
                                AttributeMetadata regarding = emailme.EntityMetadata.Attributes.Where(x => x.LogicalName == "regardingobjectid").First();
                                FormFieldData regardingFieldData = new FormFieldData(regarding);
                                regardingFieldData.FieldData = toReference;
                                fields.Add(regardingFieldData);

                                // Pass generated data as parameters
                                object[] parameters = new object[] { null, fields, emailme };
                                CRMHelper.temporaryData = parameters;
                                // Then route to RecordModifyPage
                                rootFrame.Navigate(typeof(EmailPage));
                            }
                            return;
                        case "Phone":
                            await Launcher.LaunchUriAsync(new Uri("callto:" + field.FieldData));
                            return;
                        case "Url":
                            await Launcher.LaunchUriAsync(new Uri(field.FieldData.ToString()));
                            return;
                    }
                    return;
                default:
                    break;
            }
        }

        /// <summary>
        /// Retrives an attachment for note. I do not make cache re-retreivalbe here, but if you want you can do 
        /// it by adding annotation id with it.
        /// As I store downloaded file to local folder and return StorageFile, this is not Xamarin compatible
        /// </summary>
        /// <param name="annotationId">note id</param>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task<StorageFile> RetrieveNoteAttachment(Guid annotationId)
        {
            string errorMessage = "";
            try
            {
                // Before doing all initialize work, make sure AccessToken is valid.
                await Util.EnsureToken();

                // Only retrieve filename, mimetype and documentbody.
                Annotation record = (Annotation)await CRMHelper.RetrieveRecord(Annotation.EntityLogicalName, annotationId, new ColumnSet("filename", "mimetype", "documentbody"));

                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile noteAttachment = await localFolder.CreateFileAsync(record.FileName, CreationCollisionOption.ReplaceExisting);
                //noteAttachment. = record.FileName;
                await FileIO.WriteBytesAsync(noteAttachment, Convert.FromBase64String(record.DocumentBody));

                return noteAttachment;
            }
            catch (OrganizationServiceFault ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                // need to handle non-crm error
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Util.ShowMessage(errorMessage);
            }
            return null;
        }

        #endregion

        #endregion
    }
}

