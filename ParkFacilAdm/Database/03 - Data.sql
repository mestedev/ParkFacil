INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Reportes', 0, 1, '#', 'fa fa-bar-chart-o');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Administracion ParkFacil', 0, 2, '#', 'fa fa-car');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Administracion', 0, 3, '#', 'fa fa-gear');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Otro', 0, 4, '#', 'fa fa-building-o');

INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Consolidado en el año',      (SELECT MenuID from Menu Where DisplayName='Reportes'), 1, '/Suppliers', 'fa fa-bar-chart-o');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Reportes por Operador',      (SELECT MenuID from Menu Where DisplayName='Reportes'), 2, '/Suppliers', 'fa fa-bar-chart-o');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Reportes por Estacionamientos',      (SELECT MenuID from Menu Where DisplayName='Reportes'), 3, '/Suppliers', 'fa fa-bar-chart-o');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Otro1',      (SELECT MenuID from Menu Where DisplayName='Reportes'), 4, '/Suppliers', 'fa fa-bar-chart-o');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Otro2',      (SELECT MenuID from Menu Where DisplayName='Reportes'), 5, '/Suppliers', 'fa fa-bar-chart-o');

INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Operador',   (SELECT MenuID from Menu Where DisplayName='Administracion ParkFacil'), 1, '/Usuario/Index', 'fa fa-user');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Planes y Tarifas', (SELECT MenuID from Menu Where DisplayName='Administracion ParkFacil'), 2, '/Engineering/Categorie', 'fa fa-gears');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Clientes',      (SELECT MenuID from Menu Where DisplayName='Administracion ParkFacil'), 3, '/Engineering/Lines', 'fa fa-gears');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Estacionamiento', (SELECT MenuID from Menu Where DisplayName='Administracion ParkFacil'), 4, '/Inventory/Invoices', 'fa fa-building-o');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Otro4', (SELECT MenuID from Menu Where DisplayName='Administracion ParkFacil'), 5, '/Inventory/Invoices', 'fa fa-building-o');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Otro5', (SELECT MenuID from Menu Where DisplayName='Administracion ParkFacil'), 6, '/Inventory/Invoices', 'fa fa-building-o');

INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Users', (SELECT MenuID from Menu Where DisplayName='System'), 1, '/AdminUsers/Index', 'fa fa-gear');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Roles', (SELECT MenuID from Menu Where DisplayName='System'), 2, '/AdminRoles/Index', 'fa fa-gear');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Permission', (SELECT MenuID from Menu Where DisplayName='System'), 3, '/Permissions/Index', 'fa fa-gear');
INSERT INTO Menu (DisplayName, ParentMenuID, OrderNumber, MenuURL, MenuIcon) VALUES ('Colors', (SELECT MenuID from Menu Where DisplayName='System'), 4, '/System/ColorIndex', 'fa fa-gear');



INSERT INTO Permission (MenuID, RoleID) VALUES (1, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (2, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (3, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (4, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (5, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (6, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (7, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (8, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (9, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (10, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (11, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (12, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (13, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (14, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (15, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (16, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (17, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (18, (Select Id from AspNetRoles WHERE Name='Administrador'));
INSERT INTO Permission (MenuID, RoleID) VALUES (19, (Select Id from AspNetRoles WHERE Name='Administrador'));
