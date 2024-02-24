-- create table t_author(id uuid NOT NULL, name varchar(255) NOT NULL, email varchar(255) NOT NULL) 
CREATE TABLE public.t_author(
	id uuid NOT NULL,
	name varchar(255) NOT NULL,
	email varchar(255) NOT NULL
);

-- create constraint PRIMARY KEY on t_author.id
ALTER TABLE public.t_author ADD PRIMARY KEY (id);

-- create constraint to avoid t_author.id to be equals an empty uuid
ALTER TABLE public.t_author 
ADD CONSTRAINT check_t_author_id_not_empty CHECK (id <> '00000000-0000-0000-0000-000000000000')
