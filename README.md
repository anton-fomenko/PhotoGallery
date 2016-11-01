# PhotoGallery

Небольшие разъяснения по выполненной работе:

Dump баз данных находится в папке Database в репозитории проекта. Там два файла - один для создания базы, которую использует Identity для аутентификации пользователей.
И второй файл - для базы где хранятся остальные данные приложения. В том числе логи исключений. Для добавления логики перехвата исключений я использовал стороннюю библиотеку Elmah.

Сredentials для тестого обычного пользователя:
Логин: freeuser@test.com 
Пароль: Password1!

Сredentials для тестого платного пользователя (на текущий момент приложение не позволяет создать нового платного пользователя, при регистрации создаётся обычный пользователь):
Логин: paiduser@test.com
Пароль: Password1!

Добавить картинку в альбом можно на странице Photos воспользовавшись кнопкой Add to Album под каждой фотографией.

В проекте использовал Lazy Loading. Оно было нужно, чтобы не загружать лишние данные по сущности из базы когда нужна только часть из них. Например сущность Album имеет множество фотографий. И мы обращаемся к сущности Album на странице добавления фотографии в альбом (на этой странице есть dropdownlist который содержит имена альбомов) При обращении к Album не нужно подгружать связанные с ним фото, так как это повлияет на производительность. Поэтому здесь используется Lazy Loading, которое имплементирована в EF по умолчанию (нужно было просто указать virtual модификатор для навигационного свойства).

Для предотвращения Session hijacking и других атак, можно включить глобальный фильтр RequireHttps (Я закомментировал его в классе FilterConfig, чтобы не приходилось настраивать сервер для работы через SSL).

На главной странице кнопка SEARCH PHOTO осуществляет поиск по имени фотографии. Введённое название должно полностью совпадать (включая регистр) с записью в базе.
Это же относится и к расширенному поиску по свойствам фотографий.

Для выполнения пункта задания "использовать свои custom helpers" я создал класс HtmlHelpers с методом Image (расположен в папке Helpers). В проекте есть ещё места где целесообразно вынести логику формирования html из View в хелпер, но за недостатком времени я это отложил.

Ограничение на максимального числа альбомов и фотографий у обычного пользователя можно изменить в Web.config в секции appSettings по следующим ключам:
        <add key="freePhotosLimit" value="30" />
        <add key="freeAlbumsLimit" value="5" />
