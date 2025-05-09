-- Inserción de Países
INSERT INTO pais (nombre) VALUES 
('Colombia'),
('México'),
('España'),
('Argentina'),
('Chile'),
('Perú'),
('Ecuador'),
('Venezuela'),
('Brasil'),
('Uruguay');

-- Inserción de Regiones
INSERT INTO region (nombre, pais_id) VALUES 
('Antioquia', 1),
('Cundinamarca', 1),
('Valle del Cauca', 1),
('Atlántico', 1),
('Bolívar', 1),
('Ciudad de México', 2),
('Jalisco', 2),
('Nuevo León', 2),
('Cataluña', 3),
('Madrid', 3),
('Buenos Aires', 4),
('Córdoba', 4),
('Santiago', 5),
('Valparaíso', 5),
('Lima', 6),
('Arequipa', 6),
('Guayas', 7),
('Pichincha', 7),
('Caracas', 8),
('Zulia', 8),
('São Paulo', 9),
('Río de Janeiro', 9),
('Montevideo', 10),
('Canelones', 10);

-- Inserción de Ciudades
INSERT INTO ciudad (nombre, region_id) VALUES 
('Medellín', 1),
('Bello', 1),
('Envigado', 1),
('Bogotá', 2),
('Chía', 2),
('Cali', 3),
('Palmira', 3),
('Barranquilla', 4),
('Soledad', 4),
('Cartagena', 5),
('Ciudad de México', 6),
('Guadalajara', 7),
('Monterrey', 8),
('Barcelona', 9),
('Madrid', 10),
('Buenos Aires', 11),
('Córdoba', 12),
('Santiago', 13),
('Valparaíso', 14),
('Lima', 15),
('Arequipa', 16),
('Guayaquil', 17),
('Quito', 18),
('Caracas', 19),
('Maracaibo', 20),
('São Paulo', 21),
('Río de Janeiro', 22),
('Montevideo', 23),
('Las Piedras', 24);

-- Inserción de Empresas
INSERT INTO empresa (id, nombre, ciudad_id, fecha_registro) VALUES 
('EMP001', 'TechSolutions SA', 1, '2020-01-15'),
('EMP002', 'GlobalTech Colombia', 4, '2019-05-20'),
('EMP003', 'Innovación Digital', 6, '2021-03-10'),
('EMP004', 'Servicios Empresariales', 8, '2018-11-30'),
('EMP005', 'Consultoría Integral', 10, '2022-02-28');

-- Inserción de Facturación
INSERT INTO facturacion (fechaResolucion, numInicio, numFinal, factura_actual) VALUES 
('2024-01-01', 1, 1000, 1),
('2024-01-01', 1001, 2000, 1001),
('2024-01-01', 2001, 3000, 2001);

-- Inserción de Planes
INSERT INTO plan (nombre, fecha_inicio, fecha_fin, descuento) VALUES 
('Plan Básico', '2024-01-01', '2024-12-31', 0.00),
('Plan Premium', '2024-01-01', '2024-12-31', 0.15),
('Plan Empresarial', '2024-01-01', '2024-12-31', 0.25),
('Plan VIP', '2024-01-01', '2024-12-31', 0.30);

-- Inserción de Productos
INSERT INTO producto (id, nombre, stock, stockMin, stockMax, fecha_creacion, fecha_actualizacion, codigo_barra) VALUES 
('PROD001', 'Laptop HP', 50, 10, 100, '2024-01-01', '2024-01-01', '7501234567890'),
('PROD002', 'Monitor Dell', 30, 5, 50, '2024-01-01', '2024-01-01', '7501234567891'),
('PROD003', 'Teclado Mecánico', 100, 20, 200, '2024-01-01', '2024-01-01', '7501234567892'),
('PROD004', 'Mouse Gaming', 80, 15, 150, '2024-01-01', '2024-01-01', '7501234567893'),
('PROD005', 'Impresora HP', 25, 5, 40, '2024-01-01', '2024-01-01', '7501234567894');

-- Inserción de Plan-Producto
INSERT INTO plan_producto (plan_id, producto_id) VALUES 
(1, 'PROD001'),
(1, 'PROD002'),
(2, 'PROD001'),
(2, 'PROD002'),
(2, 'PROD003'),
(3, 'PROD001'),
(3, 'PROD002'),
(3, 'PROD003'),
(3, 'PROD004'),
(4, 'PROD001'),
(4, 'PROD002'),
(4, 'PROD003'),
(4, 'PROD004'),
(4, 'PROD005');

-- Inserción de Tipos de Movimiento de Caja
INSERT INTO tipoMovCaja (nombre, tipoMovimiento) VALUES 
('Venta', 'Entrada'),
('Compra', 'Salida'),
('Gasto Operativo', 'Salida'),
('Pago de Nómina', 'Salida'),
('Ingreso por Servicios', 'Entrada');

-- Inserción de Tipos de Documento
INSERT INTO tipo_documento (descripcion) VALUES 
('Cédula de Ciudadanía'),
('Cédula de Extranjería'),
('Pasaporte'),
('NIT'),
('Tarjeta de Identidad');

-- Inserción de Tipos de Tercero
INSERT INTO tipo_tercero (descripcion) VALUES 
('Cliente'),
('Proveedor'),
('Empleado'),
('Cliente y Proveedor'),
('Empleado y Cliente');

-- Inserción de EPS
INSERT INTO eps (nombre) VALUES 
('Sura'),
('Nueva EPS'),
('Sanitas'),
('Coomeva'),
('Compensar');

-- Inserción de ARL
INSERT INTO arl (nombre) VALUES 
('Sura'),
('Positiva'),
('Colmena'),
('Bolívar'),
('Liberty');

-- Inserción de Terceros
INSERT INTO tercero (id, nombre, apellidos, email, tipo_documento_id, tipo_tercero_id, ciudad_id) VALUES 
('CC1234567890', 'Juan', 'Pérez', 'juan.perez@email.com', 1, 1, 1),
('CC2345678901', 'María', 'González', 'maria.gonzalez@email.com', 1, 2, 4),
('CC3456789012', 'Carlos', 'Rodríguez', 'carlos.rodriguez@email.com', 1, 3, 6),
('CC4567890123', 'Ana', 'Martínez', 'ana.martinez@email.com', 1, 4, 8),
('CC5678901234', 'Pedro', 'López', 'pedro.lopez@email.com', 1, 5, 10);

-- Inserción de Clientes
INSERT INTO cliente (tercero_id, fecha_nacimiento, fecha_compra) VALUES 
('CC1234567890', '1990-05-15', '2024-01-10'),
('CC4567890123', '1985-08-20', '2024-01-15'),
('CC5678901234', '1995-03-25', '2024-01-20');

-- Inserción de Proveedores
INSERT INTO proveedor (tercero_id, descuento, dia_pago) VALUES 
('CC2345678901', 0.10, 15),
('CC4567890123', 0.15, 30);

-- Inserción de Teléfonos de Terceros
INSERT INTO tercero_telefono (numero, tercero_id, tipo_telefono) VALUES 
('3001234567', 'CC1234567890', 'Movil'),
('6012345678', 'CC1234567890', 'Fijo'),
('3002345678', 'CC2345678901', 'Movil'),
('3003456789', 'CC3456789012', 'Movil'),
('3004567890', 'CC4567890123', 'Movil'),
('3005678901', 'CC5678901234', 'Movil');

-- Inserción de Empleados
INSERT INTO empleado (tercero_id, fecha_ingreso, salario_base, eps_id, arl_id) VALUES 
('CC3456789012', '2023-01-01', 2500000, 1, 1),
('CC5678901234', '2023-06-01', 3000000, 2, 2);

-- Inserción de Movimientos de Caja
INSERT INTO movimientoCaja (fecha, tipoMovimiento_id, valor, concepto, tercero_id) VALUES 
('2024-01-15', 1, 1500000, 'Venta de productos', 'CC1234567890'),
('2024-01-16', 2, 800000, 'Compra de inventario', 'CC2345678901'),
('2024-01-17', 3, 200000, 'Pago de servicios', NULL),
('2024-01-18', 4, 5000000, 'Pago de nómina', NULL),
('2024-01-19', 5, 1000000, 'Servicio de consultoría', 'CC4567890123');

-- Inserción de Compras
INSERT INTO compra (terceroProveedor_id, fecha, terceroEmpleado_id, DocCompra) VALUES 
('CC2345678901', '2024-01-16', 'CC3456789012', 'FAC-001'),
('CC4567890123', '2024-01-20', 'CC5678901234', 'FAC-002');

-- Inserción de Detalles de Compra
INSERT INTO detalle_compra (fecha, producto_id, cantidad, valor, compra_id) VALUES 
('2024-01-16', 'PROD001', 5, 2500000, 1),
('2024-01-16', 'PROD002', 3, 900000, 1),
('2024-01-20', 'PROD003', 10, 500000, 2),
('2024-01-20', 'PROD004', 8, 400000, 2);

-- Inserción de Ventas
INSERT INTO venta (factura_id, fecha, terceroEmpleado_id, terceroCliente_id) VALUES 
(1, '2024-01-15', 'CC3456789012', 'CC1234567890'),
(2, '2024-01-18', 'CC5678901234', 'CC4567890123');

-- Inserción de Detalles de Venta
INSERT INTO detalle_venta (factura_id, producto_id, cantidad, valor) VALUES 
(1, 'PROD001', 1, 600000),
(1, 'PROD002', 1, 350000),
(2, 'PROD003', 2, 120000),
(2, 'PROD004', 1, 80000);

-- Inserción de Producto-Proveedor
INSERT INTO producto_proveedor (tercero_id, producto_id) VALUES 
('CC2345678901', 'PROD001'),
('CC2345678901', 'PROD002'),
('CC4567890123', 'PROD003'),
('CC4567890123', 'PROD004'),
('CC4567890123', 'PROD005'); 