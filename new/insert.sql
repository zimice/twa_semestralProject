BEGIN TRANSACTION;

INSERT INTO equipment (name, type, quantity, lastChecked)
VALUES 
    ('Defibrillator', 'Device', 10, '2023-05-25'),
    ('Ventilator', 'Device', 7, '2023-05-26'),
    ('Surgical Mask', 'Supply', 300, '2023-05-25'),
    ('Stethoscope', 'Device', 15, '2023-05-26'),
    ('IV Stand', 'Furniture', 20, '2023-05-24');

COMMIT;
