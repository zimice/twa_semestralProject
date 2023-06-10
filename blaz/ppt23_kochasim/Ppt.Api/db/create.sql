CREATE TABLE HospitalEquipment (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    isRevisionNeeded INTEGER NOT NULL DEFAULT 0,
    isEditable INTEGER NOT NULL DEFAULT 0,
    price INTEGER NOT NULL DEFAULT 0,
    BoughtDateTime TEXT,
    LastRevisionDateTime TEXT
);
