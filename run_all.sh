for d in *.App/; do
    cd $d
    echo "${d%.App/}"
    dotnet run
    echo
    cd ..
done