# Запуск генератора облака слов

Для запуска программы генерирующей раскладку облака слов, данных в файле нужно перейти в директорию клиента и запустить программу

```cd TagCloud.Client```


```dotnet run --inputFile .\test.txt --boringWordsFile .\boringwords.txt --colorizer palette --colors "#ff00ff,#ff0000,#008000"```

Все доступные опции можно посмотреть в CLI/CliOptions.cs