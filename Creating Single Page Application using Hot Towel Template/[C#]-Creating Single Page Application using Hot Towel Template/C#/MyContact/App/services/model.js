define(['durandal/system', 'services/logger'],
    function (system, logger) {
        var nulloDate = new Date(1900, 0, 1);
        var referenceCheckValidator;
        var Validator = breeze.Validator;

        var orderBy = {
            contact: 'Name'
        };

        //If more than one entity available, it has to mention here.
        var entityNames = {
            contact: 'Contact'
        };

        var model = {
            configureMetadataStore: configureMetadataStore,
            createNullos: createNullos,
            entityNames: entityNames,
            orderBy: orderBy
        };

        return model;
        
        function configureMetadataStore(metadataStore) {
            metadataStore.registerEntityTypeCtor(
               'Contact', function () { this.isPartial = false; });

            referenceCheckValidator = createReferenceCheckValidator();
            Validator.register(referenceCheckValidator);
            log('Validators registered');
        }

        function createReferenceCheckValidator() {
            var name = 'realReferenceObject';
            var ctx = { messageTemplate: 'Missing %displayName%' };
            var val = new Validator(name, valFunction, ctx);
            log('Validators created');
            return val;

            function valFunction(value, context) {
                return value ? value.id() !== 0 : true;
            }
        }

        function createNullos(manager) {
            var unchanged = breeze.EntityState.Unchanged;
            function createNullo(entityName, values) {
                var initialValues = values
                    || { name: ' [Select a ' + entityName.toLowerCase() + ']' };
                return manager.createEntity(entityName, initialValues, unchanged);
            }

        }

        function personInitializer(person) {
            person.name = ko.computed({
                read: function () {
                    var text = person.name();
                    return text ? text.replace(/\|/g, ', ') : text;
                },
                write: function (value) {
                    person.name(value.replace(/\, /g, '|'));
                }
            });
        }

        function log(msg, data, showToast) {
            logger.log(msg, data, system.getModuleId(model), showToast);
        }
        
    });