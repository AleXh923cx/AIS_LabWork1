-- Зайдите в новое созданное вам БД (*.mdf), создай таблицу и скопируйте SQL код здесь, чтобы работал
-- Учтите: в Console ширина полей (Name, Genus) помимо настройки в ShowTable, также зависит и от значении максимальной длины двух NCHAR переменных (Name, Genus) в SQL коде

CREATE TABLE [dbo].[Characters] (
    [Id]    INT        IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (14) NOT NULL,
    [Genus] NVARCHAR (12) NOT NULL,
    [Age]   INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);