CREATE TABLE `Roles` (
	`id` int NOT NULL AUTO_INCREMENT,
	`role` varchar(32) NOT NULL UNIQUE,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Customers` (
	`id` int NOT NULL AUTO_INCREMENT,
	`user_id` int NOT NULL,
	`discount` int NOT NULL,
	`total` int NOT NULL,
	`image_id` int NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Categories` (
	`id` int NOT NULL AUTO_INCREMENT,
	`category` varchar(64) NOT NULL UNIQUE,
	PRIMARY KEY (`id`)
);

CREATE TABLE `SubCategories` (
	`id` int NOT NULL AUTO_INCREMENT,
	`subcategory` varchar(64) NOT NULL UNIQUE,
	`category_id` int NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Items` (
	`id` int NOT NULL AUTO_INCREMENT,
	`item_name` varchar(128) NOT NULL,
	`subcategory_id` int NOT NULL,
	`price_in` int NOT NULL,
	`price_sale` int NOT NULL,
	`info` varchar(255) NOT NULL,
	`rate` double NOT NULL,
	`image_id` int NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Images` (
	`id` int NOT NULL AUTO_INCREMENT,
	`image_path` varchar(255) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Sales` (
	`id` int NOT NULL AUTO_INCREMENT,
	`customer_id` int NOT NULL,
	`item_id` int NOT NULL,
	`sale_date` DATE NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Users` (
	`id` int NOT NULL AUTO_INCREMENT,
	`login` varchar(32) NOT NULL UNIQUE,
	`pass` varchar(128) NOT NULL,
	`email` varchar(128) NOT NULL UNIQUE,
	`active` bit NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `User_Role` (
	`id` int NOT NULL,
	`role_id` int NOT NULL,
	`user_id` int NOT NULL
);

ALTER TABLE `Customers` ADD CONSTRAINT `Customers_fk0` FOREIGN KEY (`user_id`) REFERENCES `Users`(`id`);

ALTER TABLE `Customers` ADD CONSTRAINT `Customers_fk1` FOREIGN KEY (`image_id`) REFERENCES `Images`(`id`);

ALTER TABLE `SubCategories` ADD CONSTRAINT `SubCategories_fk0` FOREIGN KEY (`category_id`) REFERENCES `Categories`(`id`);

ALTER TABLE `Items` ADD CONSTRAINT `Items_fk0` FOREIGN KEY (`subcategory_id`) REFERENCES `SubCategories`(`id`);

ALTER TABLE `Items` ADD CONSTRAINT `Items_fk1` FOREIGN KEY (`image_id`) REFERENCES `Images`(`id`);

ALTER TABLE `Sales` ADD CONSTRAINT `Sales_fk0` FOREIGN KEY (`customer_id`) REFERENCES `Customers`(`id`);

ALTER TABLE `Sales` ADD CONSTRAINT `Sales_fk1` FOREIGN KEY (`item_id`) REFERENCES `Items`(`id`);

ALTER TABLE `User_Role` ADD CONSTRAINT `User_Role_fk0` FOREIGN KEY (`role_id`) REFERENCES `Roles`(`id`);

ALTER TABLE `User_Role` ADD CONSTRAINT `User_Role_fk1` FOREIGN KEY (`user_id`) REFERENCES `Users`(`id`);

