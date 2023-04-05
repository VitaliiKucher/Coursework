-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Хост: localhost:3306
-- Время создания: Июл 17 2022 г., 18:27
-- Версия сервера: 5.7.24
-- Версия PHP: 8.0.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `termpaper`
--

-- --------------------------------------------------------

--
-- Структура таблицы `abiturients`
--

CREATE TABLE `abiturients` (
  `id` int(11) UNSIGNED NOT NULL,
  `PIB` varchar(50) NOT NULL,
  `Faculty` varchar(100) NOT NULL,
  `Stupin` varchar(100) NOT NULL,
  `FormStudy` varchar(100) NOT NULL,
  `Group` varchar(100) NOT NULL,
  `Special` varchar(50) NOT NULL,
  `Programma` varchar(100) NOT NULL,
  `AvgPoint` int(3) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `abiturients`
--

INSERT INTO `abiturients` (`id`, `PIB`, `Faculty`, `Stupin`, `FormStudy`, `Group`, `Special`, `Programma`, `AvgPoint`) VALUES
(1, 'Кучер Віталій Віталійович', 'ФІКТ', 'Бакалавр', 'Денна', 'КБ-21-2', '125 Кібербезпека', 'Кібербезпека', 75),
(2, 'Петренко Дмитро Володимирович', 'ФІКТ', 'Бакалавр', 'Денна', 'КБ-21-2', '125 Кібербезпека', 'Кібербезпека', 56),
(3, 'Атаманчук Денис Олегович', 'ФІКТ', 'Бакалавр', 'ДеннаФ', 'КБ-21-2', '125 Кібербезпека', 'Кібербезпека', 56),
(4, 'Біленький Владислав Олександрович', 'ФІКТ', 'Бакалавр', 'Денна', 'КБ-21-2', '125 Кібербезпека', 'Кібербезпека', 56),
(5, 'Харитонюк Юрій Андрійович', 'ФІКТ', 'Бакалавр', 'Денна', 'КБ-21-2', '125 Кібербезпека', 'Кібербезпека', 56),
(15, 'Новіцький Віктор Сергійович', 'ФІКТ', 'Бакалавр', 'Денна', 'КБ-21-2', 'Кібербезпека', '125 Кібербезпека', 56),
(16, 'Петренко Дмитро Ялох', 'ФІКТ', 'Бакалавр', 'Денна', 'КБ-21-2', '125 кібербезпека', 'кібербезпека', 56),
(17, 'Загривий Артур Сергійович', 'ФІКТ', 'Бакалавр', 'Денна', 'КБ-21-2', '125 Кібербезпека', 'Кібербезпека', 100),
(18, 'Мась Кирило Сергійович', 'ФІКТ', 'Бакалавр', 'Денна', 'КБ-21-2', '125 Кібербезпека', 'Кібербезпека', 50),
(19, 'Гайдученко Євген Олегович', 'ФІКТ', 'Бакалавр', 'Денна', 'КБ-21-2', '125 Кібербезпека', 'Кібербезпека', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `points`
--

CREATE TABLE `points` (
  `id` int(11) UNSIGNED NOT NULL,
  `PIB` varchar(100) NOT NULL,
  `English` int(3) UNSIGNED NOT NULL,
  `Programing` int(3) UNSIGNED NOT NULL,
  `PhysicalCulture` int(3) UNSIGNED NOT NULL,
  `Physic` int(3) UNSIGNED NOT NULL,
  `Ukrainian` int(3) UNSIGNED NOT NULL,
  `WEB` int(3) UNSIGNED NOT NULL,
  `Math` int(3) UNSIGNED NOT NULL,
  `Computer` int(3) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `points`
--

INSERT INTO `points` (`id`, `PIB`, `English`, `Programing`, `PhysicalCulture`, `Physic`, `Ukrainian`, `WEB`, `Math`, `Computer`) VALUES
(1, 'Кучер Віталій Віталійович', 89, 100, 89, 89, 89, 50, 50, 50),
(2, 'Петренко Дмитро Дмитрович', 100, 50, 50, 50, 50, 50, 50, 50);

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `id` int(11) UNSIGNED NOT NULL,
  `login` varchar(100) NOT NULL,
  `pass` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id`, `login`, `pass`) VALUES
(1, 'admin', 'admin'),
(33, 'Kucher', 'Vitalii'),
(32, 'Кучер Я', 'admin'),
(31, 'adm', 'admin'),
(27, 'Vitalyaa', 'Vitalya'),
(2, 'admi', 'admin'),
(34, 'Vitalii', 'kucher'),
(35, 'Кучер', 'Кучер');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `abiturients`
--
ALTER TABLE `abiturients`
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `PIB` (`PIB`),
  ADD KEY `AvgPoint` (`AvgPoint`);

--
-- Индексы таблицы `points`
--
ALTER TABLE `points`
  ADD PRIMARY KEY (`id`),
  ADD KEY `PIB` (`PIB`),
  ADD KEY `AvgPoint` (`Computer`),
  ADD KEY `AvgPoint_2` (`Computer`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `abiturients`
--
ALTER TABLE `abiturients`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT для таблицы `points`
--
ALTER TABLE `points`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
