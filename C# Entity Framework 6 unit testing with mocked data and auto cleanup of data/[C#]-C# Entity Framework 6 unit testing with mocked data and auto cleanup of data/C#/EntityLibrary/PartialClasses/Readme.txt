For each class in the entity you want to test, create and destroy objects
you need to Implements IBaseEntity so each class has a Identifier property that
returns your primary key which in turn is used in TestBase.vb to destroy the 
data created in the unit test.