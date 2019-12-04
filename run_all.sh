for d in *.App/; do
    cd $d
    echo "${d%.App/}"
    dotnet run --configuration Release
    echo
    cd ..
done