
define([
    'durandal/system',
    'services/model',
     'config',
    'services/logger',
    'services/breeze.partial-entities',
    'plugins/router'],
    function (system, model, config, logger, partialMapper, router) {
        var EntityQuery = breeze.EntityQuery;
        var manager = configureBreezeManager();
        var orderBy = model.orderBy;
        var entityNames = model.entityNames;

        //This method get all the contacts available in the database and load the data into convtactObservable variable.
        //Knockout framework will communicate these information to UI (html)
        var getAllContactDetails = function (contactObservable) {

            var query = EntityQuery.from('Contacts')
                .select('id, name, mobile, email')
                .orderBy('id');
            return manager.executeQuery(query)
                        .then(querySucceeded)
                        .fail(queryFailed);

            function querySucceeded(data) {
                var list = partialMapper.mapDtosToEntities(
                    manager, data.results, entityNames.contact, 'id');

                if (contactObservable) {
                    contactObservable(list);
                }
                log('Retrieved [' + entityNames.contact + '] from remote data source',
                    data, true);

            }
        };

        //This method get all the contacts available in the database and load the data into convtactObservable variable.        
        var getAllContactDetailsWithSearch = function (contactObservable, search) {

            var query = EntityQuery.from('Contacts')
                .select('id, name, mobile, email')
                .where('name', 'substringof', search)
                .orderBy('id');
            return manager.executeQuery(query)
                        .then(querySucceeded)
                        .fail(queryFailed);

            function querySucceeded(data) {
                var list = partialMapper.mapDtosToEntities(
                    manager, data.results, entityNames.contact, 'id');

                if (contactObservable) {
                    contactObservable(list);
                }
                log('Retrieved [' + entityNames.contact + '] from remote data source',
                    data, true);

            }
        };

        //Metabase will sync with model.js 
        function configureBreezeManager() {
            breeze.NamingConvention.camelCase.setAsDefault();
            var mgr = new breeze.EntityManager(config.remoteServiceName);
            model.configureMetadataStore(mgr.metadataStore);
            return mgr;
        }

        //This method create empty contact object and send to the view
        var createContact = function (contact) {
            //hasMetadataFor  will get call while contactadd.html call in the very first time.
            //Bacause model.js is not know the metadata object while calling createContact funtion in the very first time
            if (!manager.metadataStore.hasMetadataFor(config.remoteServiceName)) {
                manager.metadataStore.fetchMetadata(config.remoteServiceName, fetchMetadataSuccess, fetchMetadataSuccess);
            } else {
                contact(manager.createEntity(entityNames.contact));
            }

            function fetchMetadataSuccess(rawMetadata) {
                contact(manager.createEntity(entityNames.contact));
            }

            function fetchMetadataFail(exception) {

            }
        };


        //This method save the modified/added contact to the datatabase with the help of Breeze framework.        
        var saveChanges = function () {
            return manager.saveChanges()
                .then(saveSucceeded)
                .fail(saveFailed);

            function saveSucceeded(saveResult) {
                log('Saved data Successfully', saveResult, true);
            }

            function saveFailed(error) {
                var message = 'Save Failed: ' + getErrorMessages(error);
                logError(message, error);
                error.message = message;
                throw error;
            }
        };

        //This method cancel the change set managed by the breeze
        var cancelChanges = function () {
            manager.rejectChanges();
            log('Canceled changes', null, true);
        }


        ////////////////////////
        function getErrorMessages(error) {
            var msg = error.message;
            if (msg.match(/see the entityErrors collection/i)) {//Artha
                return getValidationMessages(error);
            }
            return msg;
        }

        function getValidationMessages(error) {
            try {
                //foreach entity with a validation error
                return error.entityErrors.map(function (entity) {
                    // return the error message from the validation
                    return entity.errorMessage;
                }).join('; <br/>');
            }
            catch (e) { alert('[datacontext.js] getValidationMessages : ' + e.message); }
            return 'validation error';
        }

        function queryFailed(error) {
            var msg = '[datacontext.js] Error retrieving data. ' + error.message;
            logError(msg, error);
            throw error;
        }


        function log(msg, data, showToast) {
            logger.log(msg, data, system.getModuleId(datacontext), showToast);
        }

        function logError(msg, error) {
            logger.logError(msg, error, system.getModuleId(datacontext), true);
        }
        ////////////////////////


        //This property help to find the database hasChanges
        var hasChanges = ko.observable(false);


        manager.hasChangesChanged.subscribe(function (eventArgs) {
            hasChanges(eventArgs.hasChanges);
        });


        //This method call the breeze api service and get a request contact for edit
        var getAContactDetail = function (contactId, contactObservable) {

            return manager.fetchEntityByKey(
               entityNames.contact, contactId, true)
               .then(fetchSucceeded)
               .fail(queryFailed);

            function fetchSucceeded(data) {
                var s = data.entity;
                return s.isPartial() ? refreshcontact(s) : contactObservable(s);
            }

            function refreshcontact(contact) {
                return EntityQuery.fromEntities(contact)
                    .using(manager).execute()
                    .then(querySucceeded)
                    .fail(queryFailed);
            }

            function querySucceeded(data) {
                var s = data.results[0];
                s.isPartial(false);
                log('Retrieved [' + entityNames.contact + '] from remote data source', s, true);
                return contactObservable(s);
            }
        };


        ///Properties, Methods
        var datacontext = {
            getAllContactDetails: getAllContactDetails,
            createContact: createContact,
            hasChanges: hasChanges,
            saveChanges: saveChanges,
            cancelChanges: cancelChanges,
            getAContactDetail: getAContactDetail,
            getAllContactDetailsWithSearch: getAllContactDetailsWithSearch
        };

        return datacontext;
    });
