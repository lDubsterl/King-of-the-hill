# Unity-game
# Требования к проекту
---

# Содержание
1. [Введение](#intro)  
1.1 [Назначение](#appointment)  
1.2 [Аналоги](#analogues)  
1.2.1 [Move or die](#move_or_die)  
2. [Требования пользователя](#user_requirements)  
2.1 [Программные интерфейсы](#software_interfaces)  
2.2 [Интерфейс пользователя](#user_interface)  
2.3 [Характеристики пользователей](#user_specifications)  
2.3.1 [Аудитория приложения](#application_audience)  
2.3.1.1 [Целевая аудитория](#target_audience)  
2.3.1.2 [Побочная аудитория](#collateral_audience)  
3. [Системные требования](#system_requirements)  
3.1 [Функциональные требования](#functional_requirements)  
3.1.1 [Основные функции](#main_functions)  
3.1.1.1 [Передвижение игрока](#player_movement)  
3.1.1.2 [Настройка разрешения экрана и звука](#setting_up_screen_resolution_and_volume)  
3.2 [Нефункциональные требования](#non-functional_requirements)  
3.2.1 [Атрибуты качества](#quality_attributes)  
3.2.1.1 [Требования к удобству использования](#requirements_for_ease_of_use)  
3.2.2 [Требования к производительности](#performance_requirements)  
3.2.3 [Ограничения](#restrictions)  

<a name="intro"/>

# 1 Введение

<a name="appointment"/>

## 1.1 Назначение
Десктопная игра "King of the hill" предназначена для развлечения группы игроков на картах с целью остаться выжившим.

<a name="analogues"/>

## 1.2 Аналоги

<a name="move_or_die"/>

### 1.2.1 Move or die

**Русский интерфейс:** есть  
**Цена:** 10$  
**Ссылка на сайт производителя:** https://moveordiegame.com/

Move or die - платформер, рассчитанный на прохождение в компании игроков в количестве до четырех человек.
# 2 Сравнение приложений

| Функция |  King of the hill | Move or die |
|:---|:---:|:---:|
| Поддержка русского языка | + | + |
| Бесплатное использование | + | - |
| Локальный кооператив | + | + |
| Сетевой кооператив | - | + |


<a name="user_requirements"/>

# 2 Требования пользователя

<a name="software_interfaces"/>

## 2.1 Программные интерфейсы
В основе приложения - библиотеки Unity, основанные на C#.

<a name="user_interface"/>

## 2.2 Интерфейс пользователя
Главное меню.
![Главное меню](Assets/Mockups/main-menu.jpg)

При нажатии на кнопку "Играть" - переход к окну выбора комнат.

![Список комнат](Assets/Mockups/room-list.jpg)

При нажатии на кнопку "Настройки" - переход к окну настроек.  
При нажатии на кнопку "Выход" - выход из игры.  

Настройки.

![Настройки](Assets/Mockups/settings.jpg) 

При нажатии на кнопку "Разрешение экрана" - выбор разрешения экрана.  
При перетаскивании ползунка "Звук" - изменение громкости звука.  
<a name="user_specifications"/>

## 2.3 Характеристики пользователей

<a name="application_audience"/>

### 2.3.1 Аудитория приложения

<a name="target_audience"/>

#### 2.3.1.1 Целевая аудитория
Люди юношеской возрастной категории, имеющие пк и любящие играть в игры.

<a name="collateral_audience"/>

#### 2.3.1.2 Побочная аудитория
Люди младшей и старшей возрастных категорий, имеющие пк и любящие играть в игры.

<a name="system_requirements"/>

# 3 Системные требования

<a name="functional_requirements"/>

## 3.1 Функциональные требования

<a name="main_functions"/>

### 3.1.1 Основные функции

<a name="player_movement"/>

#### 3.1.1.1 Передвижение игрока
Во время матча игрок имеет возможность передвигать персонажа клавишами WASD и space.

<a name="setting_up_screen_resolution_and_volume"/>

#### 3.1.1.2 Настройка разрешения экрана и звука
**Описание.** Игрок имеет возможность изменять разрешение экрана и громкость звуков.

<a name="non-functional_requirements"/>

## 3.2 Нефункциональные требования

<a name="quality_attributes"/>

### 3.2.1 Атрибуты качества

<a name="requirements_for_ease_of_use"/>

#### 3.2.1.1 Требования к удобству использования
1. Доступ к основным функциям Игры не более чем за две операции;
2. Все функциональные элементы пользовательского интерфейса имеют названия, описывающие действие, которое произойдет при выборе элемента;

<a name="#performance_requirements"/>

### 3.2.2 Требования к производительности
Игра запустится и будет работать при наличии процессора с тактовой частотой от 1.6Ггц, 1Gb RAM и видеокартой с памятью от 1Gb

<a name="restrictions"/>

### 3.2.3 Ограничения
1. Приложение реализовано на платформе .NET Framework 4.6.1;
