-- USE really;

-- CREATE TABLE profile (
--   userId VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL
-- )

-- CREATE TABLE homes (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     primaryImg VARCHAR(255),
--     secondaryImgs VARCHAR(255),
--     views INT DEFAULT 0,
--     favorite INT DEFAULT 0,
--     INDEX userId (userId),
--     PRIMARY KEY (id)
-- );



-- CREATE TABLE favoriteHome (
--     id int NOT NULL AUTO_INCREMENT,
--     homeId int NOT NULL,
--     userId VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id),
--     INDEX (homeId),
--     INDEX (userId),


--     FOREIGN KEY (homeId)
--         REFERENCES homes(id)
--         ON DELETE CASCADE
-- )


-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT 
-- k.*,
-- vk.id as vaultKeepId
-- FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = @vaultId AND vk.userId = @userId) 



-- -- USE THIS TO CLEAN OUT YOUR DATABASE
-- DROP TABLE IF EXISTS vaultkeeps;
-- DROP TABLE IF EXISTS vaults;
-- DROP TABLE IF EXISTS keeps;
-- DROP TABLE IF EXISTS users;
