from gpcsite import settings
from perfgraphs.models import *
from datetime import datetime
from random import randint

def main():
    settings.configure()
    C = Course
    C.date = datetime.now()
    C.distance = 5

    P = Performance
    P.course = C

    for x in range(1,10):
        for x in range(1,10):
            T = Tour
            T.temps = randint(10,20) * 5
            P.tours.add(T)

        moi = Adherents.objects.get(prenom="Quentin")
        moi.performances.all().add(P)

    moi.save()

if __name__ == "__main__":
    main()
