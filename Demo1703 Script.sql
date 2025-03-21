CREATE TABLE public.partner_types (
	id int GENERATED BY DEFAULT AS IDENTITY NOT NULL,
	name varchar NOT NULL,
	CONSTRAINT partner_types_pk PRIMARY KEY (id),
	CONSTRAINT partner_types_unique UNIQUE (name)
);

CREATE TABLE public.partners (
	id int GENERATED BY DEFAULT AS IDENTITY NOT NULL,
	"name" varchar NOT NULL,
	director varchar NOT NULL,
	email varchar NOT NULL,
	phone varchar NOT NULL,
	adress varchar NOT NULL,
	tin varchar NOT NULL,
	rating int NOT NULL,
	"type" int NOT NULL,
	CONSTRAINT partners_pk PRIMARY KEY (id),
	CONSTRAINT partners_partner_types_fk FOREIGN KEY ("type") REFERENCES public.partner_types(id) ON DELETE SET NULL ON UPDATE CASCADE
);

CREATE TABLE public.product_types (
	id int GENERATED BY DEFAULT AS IDENTITY NOT NULL,
	"name" varchar NOT NULL,
	coefficient decimal NOT NULL,
	CONSTRAINT product_types_pk PRIMARY KEY (id),
	CONSTRAINT product_types_unique UNIQUE ("name")
);

CREATE TABLE public.products (
	id int GENERATED BY DEFAULT AS IDENTITY NOT NULL,
	"name" varchar NOT NULL,
	"type" int NOT NULL,
	article varchar NOT NULL,
	minimal_cost decimal NOT NULL,
	CONSTRAINT products_pk PRIMARY KEY (id),
	CONSTRAINT products_product_types_fk FOREIGN KEY ("type") REFERENCES public.product_types(id) ON DELETE SET NULL ON UPDATE CASCADE
);

CREATE TABLE public.partners_products (
	id int GENERATED BY DEFAULT AS IDENTITY NOT NULL,
	product int NOT NULL,
	partner int NOT NULL,
	product_quantity int NOT NULL,
	sale_date date NOT NULL,
	CONSTRAINT partners_products_pk PRIMARY KEY (id),
	CONSTRAINT partners_products_partners_fk FOREIGN KEY (partner) REFERENCES public.partners(id) ON DELETE SET NULL ON UPDATE CASCADE,
	CONSTRAINT partners_products_products_fk FOREIGN KEY (product) REFERENCES public.products(id) ON DELETE SET NULL ON UPDATE CASCADE
);

CREATE TABLE public.material_types (
	id int GENERATED BY DEFAULT AS IDENTITY NOT NULL,
	"name" varchar NOT NULL,
	defect_percentage decimal NOT NULL,
	CONSTRAINT material_types_pk PRIMARY KEY (id),
	CONSTRAINT material_types_unique UNIQUE ("name")
);
