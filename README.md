[Srez1.sql](https://github.com/user-attachments/files/23133498/Srez1.sql)
--
-- PostgreSQL database dump
--

\restrict YWXHFPv69PIgMERabx8j5Kl2ulan7yPU7zwRUWTrsGcVjRcGxsaL9ECdJeIqcCX

-- Dumped from database version 18.0
-- Dumped by pg_dump version 18.0

-- Started on 2025-10-24 22:00:54

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 230 (class 1259 OID 16799)
-- Name: material; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.material (
    id integer NOT NULL,
    name character varying(150) NOT NULL,
    type_id integer,
    price numeric(12,2) NOT NULL,
    stock_quantity numeric(12,2),
    min_quantity numeric(12,2),
    pack_quantity numeric(12,2),
    unit_id integer
);


ALTER TABLE public.material OWNER TO postgres;

--
-- TOC entry 229 (class 1259 OID 16798)
-- Name: material_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.material_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.material_id_seq OWNER TO postgres;

--
-- TOC entry 5122 (class 0 OID 0)
-- Dependencies: 229
-- Name: material_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.material_id_seq OWNED BY public.material.id;


--
-- TOC entry 232 (class 1259 OID 16821)
-- Name: material_supplier; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.material_supplier (
    id integer NOT NULL,
    material_id integer NOT NULL,
    supplier_id integer NOT NULL
);


ALTER TABLE public.material_supplier OWNER TO postgres;

--
-- TOC entry 231 (class 1259 OID 16820)
-- Name: material_supplier_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.material_supplier_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.material_supplier_id_seq OWNER TO postgres;

--
-- TOC entry 5123 (class 0 OID 0)
-- Dependencies: 231
-- Name: material_supplier_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.material_supplier_id_seq OWNED BY public.material_supplier.id;


--
-- TOC entry 222 (class 1259 OID 16745)
-- Name: material_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.material_type (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    lose_percentage numeric(6,4)
);


ALTER TABLE public.material_type OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16744)
-- Name: material_type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.material_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.material_type_id_seq OWNER TO postgres;

--
-- TOC entry 5124 (class 0 OID 0)
-- Dependencies: 221
-- Name: material_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.material_type_id_seq OWNED BY public.material_type.id;


--
-- TOC entry 234 (class 1259 OID 16843)
-- Name: product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.product (
    id integer NOT NULL,
    name character varying(150) NOT NULL,
    type_id integer,
    min_partner_price numeric(12,2),
    roll_width numeric(12,2),
    param1 numeric(12,2),
    param2 numeric(12,2)
);


ALTER TABLE public.product OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 16842)
-- Name: product_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.product_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.product_id_seq OWNER TO postgres;

--
-- TOC entry 5125 (class 0 OID 0)
-- Dependencies: 233
-- Name: product_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.product_id_seq OWNED BY public.product.id;


--
-- TOC entry 236 (class 1259 OID 16859)
-- Name: product_material; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.product_material (
    id integer NOT NULL,
    product_id integer NOT NULL,
    material_id integer NOT NULL,
    material_qty numeric(12,2)
);


ALTER TABLE public.product_material OWNER TO postgres;

--
-- TOC entry 235 (class 1259 OID 16858)
-- Name: product_material_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.product_material_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.product_material_id_seq OWNER TO postgres;

--
-- TOC entry 5126 (class 0 OID 0)
-- Dependencies: 235
-- Name: product_material_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.product_material_id_seq OWNED BY public.product_material.id;


--
-- TOC entry 226 (class 1259 OID 16767)
-- Name: product_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.product_type (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    coeff_type numeric(8,3) NOT NULL
);


ALTER TABLE public.product_type OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 16766)
-- Name: product_type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.product_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.product_type_id_seq OWNER TO postgres;

--
-- TOC entry 5127 (class 0 OID 0)
-- Dependencies: 225
-- Name: product_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.product_type_id_seq OWNED BY public.product_type.id;


--
-- TOC entry 224 (class 1259 OID 16756)
-- Name: supplier_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.supplier_type (
    id integer NOT NULL,
    name character varying(50) NOT NULL
);


ALTER TABLE public.supplier_type OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 16755)
-- Name: supplier_type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.supplier_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.supplier_type_id_seq OWNER TO postgres;

--
-- TOC entry 5128 (class 0 OID 0)
-- Dependencies: 223
-- Name: supplier_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.supplier_type_id_seq OWNED BY public.supplier_type.id;


--
-- TOC entry 228 (class 1259 OID 16779)
-- Name: suppliers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.suppliers (
    id integer NOT NULL,
    name character varying(150) NOT NULL,
    type_id integer,
    inn character varying(20) NOT NULL,
    rating integer,
    start_date date,
    CONSTRAINT suppliers_rating_check CHECK (((rating >= 1) AND (rating <= 10)))
);


ALTER TABLE public.suppliers OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 16778)
-- Name: suppliers_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.suppliers_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.suppliers_id_seq OWNER TO postgres;

--
-- TOC entry 5129 (class 0 OID 0)
-- Dependencies: 227
-- Name: suppliers_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.suppliers_id_seq OWNED BY public.suppliers.id;


--
-- TOC entry 220 (class 1259 OID 16734)
-- Name: unit_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.unit_type (
    id integer NOT NULL,
    name character varying(50) NOT NULL
);


ALTER TABLE public.unit_type OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16733)
-- Name: unit_type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.unit_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.unit_type_id_seq OWNER TO postgres;

--
-- TOC entry 5130 (class 0 OID 0)
-- Dependencies: 219
-- Name: unit_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.unit_type_id_seq OWNED BY public.unit_type.id;


--
-- TOC entry 4901 (class 2604 OID 16802)
-- Name: material id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material ALTER COLUMN id SET DEFAULT nextval('public.material_id_seq'::regclass);


--
-- TOC entry 4902 (class 2604 OID 16824)
-- Name: material_supplier id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material_supplier ALTER COLUMN id SET DEFAULT nextval('public.material_supplier_id_seq'::regclass);


--
-- TOC entry 4897 (class 2604 OID 16748)
-- Name: material_type id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material_type ALTER COLUMN id SET DEFAULT nextval('public.material_type_id_seq'::regclass);


--
-- TOC entry 4903 (class 2604 OID 16846)
-- Name: product id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product ALTER COLUMN id SET DEFAULT nextval('public.product_id_seq'::regclass);


--
-- TOC entry 4904 (class 2604 OID 16862)
-- Name: product_material id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_material ALTER COLUMN id SET DEFAULT nextval('public.product_material_id_seq'::regclass);


--
-- TOC entry 4899 (class 2604 OID 16770)
-- Name: product_type id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_type ALTER COLUMN id SET DEFAULT nextval('public.product_type_id_seq'::regclass);


--
-- TOC entry 4898 (class 2604 OID 16759)
-- Name: supplier_type id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.supplier_type ALTER COLUMN id SET DEFAULT nextval('public.supplier_type_id_seq'::regclass);


--
-- TOC entry 4900 (class 2604 OID 16782)
-- Name: suppliers id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.suppliers ALTER COLUMN id SET DEFAULT nextval('public.suppliers_id_seq'::regclass);


--
-- TOC entry 4896 (class 2604 OID 16737)
-- Name: unit_type id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.unit_type ALTER COLUMN id SET DEFAULT nextval('public.unit_type_id_seq'::regclass);


--
-- TOC entry 5110 (class 0 OID 16799)
-- Dependencies: 230
-- Data for Name: material; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.material (id, name, type_id, price, stock_quantity, min_quantity, pack_quantity, unit_id) FROM stdin;
1	Глина	1	15.29	1570.00	5500.00	30.00	1
2	Каолин	1	18.20	1030.00	3500.00	25.00	1
3	Гидрослюда	1	17.20	2147.00	3500.00	25.00	1
4	Монтмориллонит	1	17.67	3000.00	3000.00	30.00	1
5	Перлит	2	13.99	150.00	1000.00	50.00	2
6	Стекло	2	2.40	3000.00	1500.00	500.00	1
7	Дегидратированная глина	2	21.95	3000.00	2500.00	20.00	1
8	Шамот	2	27.50	2300.00	1960.00	20.00	1
9	Техническая сода	3	54.55	1200.00	1500.00	25.00	1
10	Жидкое стекло	3	76.59	500.00	1500.00	15.00	1
11	Кварц	4	375.96	1500.00	2500.00	10.00	1
12	Полевой шпат	4	15.99	750.00	1500.00	100.00	1
13	Краска-раствор	5	200.90	1496.00	2500.00	5.00	2
14	Порошок цветной	5	84.39	511.00	1750.00	25.00	1
15	Кварцевый песок	2	4.29	3000.00	1600.00	50.00	1
16	Жильный кварц	2	18.60	2556.00	1600.00	25.00	1
17	Барий углекислый	4	303.64	340.00	1500.00	25.00	1
18	Бура техническая	4	125.99	165.00	1300.00	25.00	1
19	Углещелочной реагент	3	3.45	450.00	1100.00	25.00	1
20	Пирофосфат натрия	3	700.99	356.00	1200.00	25.00	1
\.


--
-- TOC entry 5112 (class 0 OID 16821)
-- Dependencies: 232
-- Data for Name: material_supplier; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.material_supplier (id, material_id, supplier_id) FROM stdin;
1	13	19
2	2	3
3	2	9
4	6	19
5	15	1
6	5	6
7	1	4
8	15	20
9	7	9
10	12	4
11	1	1
12	14	19
13	16	17
14	12	1
15	3	9
16	6	20
17	12	12
18	4	9
19	11	11
20	17	17
21	10	12
22	8	17
23	1	6
24	11	15
25	3	3
26	5	9
27	8	19
28	17	20
29	18	20
30	9	18
31	20	20
32	3	4
33	16	15
34	5	10
35	15	15
36	4	4
37	13	12
38	6	7
39	14	12
40	2	1
41	10	18
42	18	7
43	7	11
44	18	13
45	4	3
46	10	16
47	10	7
48	14	16
49	14	8
50	19	16
51	11	14
52	16	13
53	13	16
54	11	13
55	7	2
56	15	14
57	17	7
58	8	2
59	7	7
60	3	5
61	20	7
62	5	5
63	9	7
64	1	10
65	9	16
66	4	10
67	19	12
68	9	8
69	18	2
70	20	5
71	16	10
72	6	2
73	19	8
74	17	5
75	20	8
76	2	5
77	8	11
78	19	5
79	13	8
80	12	10
\.


--
-- TOC entry 5102 (class 0 OID 16745)
-- Dependencies: 222
-- Data for Name: material_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.material_type (id, name, lose_percentage) FROM stdin;
1	Пластичные материалы	0.0012
2	Добавка	0.0020
3	Электролит	0.0015
4	Глазурь	0.0030
5	Пигмент	0.0025
\.


--
-- TOC entry 5114 (class 0 OID 16843)
-- Dependencies: 234
-- Data for Name: product; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.product (id, name, type_id, min_partner_price, roll_width, param1, param2) FROM stdin;
7	пввппвпв	1	1124.00	8.00	3319.82	\N
8	Аафл	1	1245.00	5.00	2727.22	\N
\.


--
-- TOC entry 5116 (class 0 OID 16859)
-- Dependencies: 236
-- Data for Name: product_material; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.product_material (id, product_id, material_id, material_qty) FROM stdin;
\.


--
-- TOC entry 5106 (class 0 OID 16767)
-- Dependencies: 226
-- Data for Name: product_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.product_type (id, name, coeff_type) FROM stdin;
1	Тип продукции 1	1.200
2	Тип продукции 2	8.590
3	Тип продукции 3	3.450
4	Тип продукции 4	5.600
\.


--
-- TOC entry 5104 (class 0 OID 16756)
-- Dependencies: 224
-- Data for Name: supplier_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.supplier_type (id, name) FROM stdin;
1	ЗАО
2	ООО
3	ПАО
4	ОАО
\.


--
-- TOC entry 5108 (class 0 OID 16779)
-- Dependencies: 228
-- Data for Name: suppliers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.suppliers (id, name, type_id, inn, rating, start_date) FROM stdin;
1	БрянскСтройресурс	1	9432455179	8	2015-12-20
2	Стройкомплект	1	7803888520	7	2017-09-13
3	Железногорская руда	2	8430391035	7	2016-12-23
4	Белая гора	2	4318170454	8	2019-05-27
5	Тульский обрабатывающий завод 	2	7687851800	7	2015-06-16
6	ГорТехРазработка	3	6119144874	9	2021-12-27
7	Сапфир	4	1122170258	3	2022-04-10
8	ХимБытСервис	3	8355114917	5	2022-03-13
9	ВоронежРудоКомбинат	4	3532367439	8	2023-11-11
10	Смоленский добывающий комбинат	4	2362431140	3	2018-11-23
11	МосКарьер	3	4159215346	2	2012-07-07
12	КурскРесурс	1	9032455179	4	2021-07-23
13	Нижегородская разработка	4	3776671267	9	2016-05-23
14	Речная долина	4	7447864518	8	2015-06-25
15	Карелия добыча	3	9037040523	6	2017-03-09
16	Московский ХимЗавод	3	6221520857	4	2015-05-07
17	Горная компания	1	2262431140	3	2020-12-22
18	Минерал Ресурс	2	4155215346	7	2015-05-22
19	Арсенал	1	3961234561	5	2010-11-25
20	КамчаткаСтройМинералы	1	9600275878	7	2016-12-20
\.


--
-- TOC entry 5100 (class 0 OID 16734)
-- Dependencies: 220
-- Data for Name: unit_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.unit_type (id, name) FROM stdin;
1	кг
2	л
\.


--
-- TOC entry 5131 (class 0 OID 0)
-- Dependencies: 229
-- Name: material_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.material_id_seq', 20, true);


--
-- TOC entry 5132 (class 0 OID 0)
-- Dependencies: 231
-- Name: material_supplier_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.material_supplier_id_seq', 80, true);


--
-- TOC entry 5133 (class 0 OID 0)
-- Dependencies: 221
-- Name: material_type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.material_type_id_seq', 5, true);


--
-- TOC entry 5134 (class 0 OID 0)
-- Dependencies: 233
-- Name: product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.product_id_seq', 8, true);


--
-- TOC entry 5135 (class 0 OID 0)
-- Dependencies: 235
-- Name: product_material_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.product_material_id_seq', 1, false);


--
-- TOC entry 5136 (class 0 OID 0)
-- Dependencies: 225
-- Name: product_type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.product_type_id_seq', 4, true);


--
-- TOC entry 5137 (class 0 OID 0)
-- Dependencies: 223
-- Name: supplier_type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.supplier_type_id_seq', 4, true);


--
-- TOC entry 5138 (class 0 OID 0)
-- Dependencies: 227
-- Name: suppliers_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.suppliers_id_seq', 20, true);


--
-- TOC entry 5139 (class 0 OID 0)
-- Dependencies: 219
-- Name: unit_type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.unit_type_id_seq', 2, true);


--
-- TOC entry 4929 (class 2606 OID 16809)
-- Name: material material_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material
    ADD CONSTRAINT material_name_key UNIQUE (name);


--
-- TOC entry 4931 (class 2606 OID 16807)
-- Name: material material_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material
    ADD CONSTRAINT material_pkey PRIMARY KEY (id);


--
-- TOC entry 4933 (class 2606 OID 16831)
-- Name: material_supplier material_supplier_material_id_supplier_id_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material_supplier
    ADD CONSTRAINT material_supplier_material_id_supplier_id_key UNIQUE (material_id, supplier_id);


--
-- TOC entry 4935 (class 2606 OID 16829)
-- Name: material_supplier material_supplier_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material_supplier
    ADD CONSTRAINT material_supplier_pkey PRIMARY KEY (id);


--
-- TOC entry 4911 (class 2606 OID 16754)
-- Name: material_type material_type_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material_type
    ADD CONSTRAINT material_type_name_key UNIQUE (name);


--
-- TOC entry 4913 (class 2606 OID 16752)
-- Name: material_type material_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material_type
    ADD CONSTRAINT material_type_pkey PRIMARY KEY (id);


--
-- TOC entry 4941 (class 2606 OID 16867)
-- Name: product_material product_material_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_material
    ADD CONSTRAINT product_material_pkey PRIMARY KEY (id);


--
-- TOC entry 4943 (class 2606 OID 16869)
-- Name: product_material product_material_product_id_material_id_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_material
    ADD CONSTRAINT product_material_product_id_material_id_key UNIQUE (product_id, material_id);


--
-- TOC entry 4937 (class 2606 OID 16852)
-- Name: product product_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_name_key UNIQUE (name);


--
-- TOC entry 4939 (class 2606 OID 16850)
-- Name: product product_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_pkey PRIMARY KEY (id);


--
-- TOC entry 4919 (class 2606 OID 16777)
-- Name: product_type product_type_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_type
    ADD CONSTRAINT product_type_name_key UNIQUE (name);


--
-- TOC entry 4921 (class 2606 OID 16775)
-- Name: product_type product_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_type
    ADD CONSTRAINT product_type_pkey PRIMARY KEY (id);


--
-- TOC entry 4915 (class 2606 OID 16765)
-- Name: supplier_type supplier_type_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.supplier_type
    ADD CONSTRAINT supplier_type_name_key UNIQUE (name);


--
-- TOC entry 4917 (class 2606 OID 16763)
-- Name: supplier_type supplier_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.supplier_type
    ADD CONSTRAINT supplier_type_pkey PRIMARY KEY (id);


--
-- TOC entry 4923 (class 2606 OID 16792)
-- Name: suppliers suppliers_inn_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.suppliers
    ADD CONSTRAINT suppliers_inn_key UNIQUE (inn);


--
-- TOC entry 4925 (class 2606 OID 16790)
-- Name: suppliers suppliers_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.suppliers
    ADD CONSTRAINT suppliers_name_key UNIQUE (name);


--
-- TOC entry 4927 (class 2606 OID 16788)
-- Name: suppliers suppliers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.suppliers
    ADD CONSTRAINT suppliers_pkey PRIMARY KEY (id);


--
-- TOC entry 4907 (class 2606 OID 16743)
-- Name: unit_type unit_type_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.unit_type
    ADD CONSTRAINT unit_type_name_key UNIQUE (name);


--
-- TOC entry 4909 (class 2606 OID 16741)
-- Name: unit_type unit_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.unit_type
    ADD CONSTRAINT unit_type_pkey PRIMARY KEY (id);


--
-- TOC entry 4947 (class 2606 OID 16832)
-- Name: material_supplier material_supplier_material_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material_supplier
    ADD CONSTRAINT material_supplier_material_id_fkey FOREIGN KEY (material_id) REFERENCES public.material(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 4948 (class 2606 OID 16837)
-- Name: material_supplier material_supplier_supplier_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material_supplier
    ADD CONSTRAINT material_supplier_supplier_id_fkey FOREIGN KEY (supplier_id) REFERENCES public.suppliers(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 4945 (class 2606 OID 16810)
-- Name: material material_type_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material
    ADD CONSTRAINT material_type_id_fkey FOREIGN KEY (type_id) REFERENCES public.material_type(id) ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 4946 (class 2606 OID 16815)
-- Name: material material_unit_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material
    ADD CONSTRAINT material_unit_id_fkey FOREIGN KEY (unit_id) REFERENCES public.unit_type(id) ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 4950 (class 2606 OID 16875)
-- Name: product_material product_material_material_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_material
    ADD CONSTRAINT product_material_material_id_fkey FOREIGN KEY (material_id) REFERENCES public.material(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 4951 (class 2606 OID 16870)
-- Name: product_material product_material_product_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_material
    ADD CONSTRAINT product_material_product_id_fkey FOREIGN KEY (product_id) REFERENCES public.product(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 4949 (class 2606 OID 16853)
-- Name: product product_type_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_type_id_fkey FOREIGN KEY (type_id) REFERENCES public.product_type(id) ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 4944 (class 2606 OID 16793)
-- Name: suppliers suppliers_type_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.suppliers
    ADD CONSTRAINT suppliers_type_id_fkey FOREIGN KEY (type_id) REFERENCES public.supplier_type(id) ON UPDATE CASCADE ON DELETE SET NULL;


-- Completed on 2025-10-24 22:00:54

--
-- PostgreSQL database dump complete
--

--ДИАГРАММА

\unrestrict YWXHFPv69PIgMERabx8j5Kl2ulan7yPU7zwRUWTrsGcVjRcGxsaL9ECdJeIqcCX
[photo_5465338724905781598_y.pdf](https://github.com/user-attachments/files/23133521/photo_5465338724905781598_y.pdf)

