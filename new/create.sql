BEGIN TRANSACTION;

CREATE TABLE IF NOT EXISTS "equipment" (
    "id" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    "name" TEXT NOT NULL,
    "type" TEXT NOT NULL,
    "quantity" INTEGER NOT NULL,
    "lastChecked" TEXT NOT NULL
);

COMMIT;