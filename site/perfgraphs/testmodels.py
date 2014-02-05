from django.db import models
from pygal import DateY, Bar
from pygal.style import BlueStyle

class Tour(models.Model):
    id = models.AutoField(primary_key=True)
    temps = models.IntegerField()
    
class Course(models.Model):
    id = models.AutoField(primary_key=True)
    date = models.DateTimeField(auto_now_add=True)
    distance = models.IntegerField() # distance en mètres 

class Performance(models.Model):
    id = models.AutoField(primary_key=True)
    course = models.ForeignKey(Course)
    tours = models.ManyToManyField(Tour)

    def _get_vitesse(self, num_tour):
        return course.distance / tours[num_tour].temps

    def _get_fulltime(self):
        return sum([T.temps for T in tours])

    def get_vitesse_generale(self):
        return course.distance / _get_fulltime()

    def dessiner_graph_course(self):
        graph = Bar(style=style.BlueStyle)
        graph.title = "Course du %s/%s/%s"  % (course.date.day, course.date.month, course.date.year)
        graph.add ([ (str(x), _get_vitesse(x)) for x in range (0, length(tours)) ])
        return graph

class Adherent(models.Model):
    id = models.AutoField(primary_key=True)
    adresse = models.CharField(max_length=2000)
    nom = models.CharField(max_length=200)
    prenom = models.CharField(max_length=200)
    code_carte = models.CharField(max_length=20)
    performances = models.ManyToManyField(Performance, blank=True)

    def dessiner_graph_global(self):
        graph = DateY(style=style.BlueStyle)
        graph.title = "Performances générales de %s %s" % (prenom, nom)
        graph.add ([ (P.course.date, P.get_vitesse_generale) for P in performances ])
        return graph
