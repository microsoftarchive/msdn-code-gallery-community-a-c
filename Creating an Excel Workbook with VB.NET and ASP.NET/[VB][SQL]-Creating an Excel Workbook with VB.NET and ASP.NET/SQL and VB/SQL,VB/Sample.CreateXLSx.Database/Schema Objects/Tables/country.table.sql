CREATE TABLE [dbo].[country] (
    [iso]            CHAR (2)     NOT NULL,
    [name]           VARCHAR (80) NOT NULL,
    [printable_name] VARCHAR (80) NOT NULL,
    [iso3]           CHAR (3)     NULL,
    [numcode]        SMALLINT     NULL,
    PRIMARY KEY CLUSTERED ([iso] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

