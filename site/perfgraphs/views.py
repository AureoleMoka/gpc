from django.shortcuts import render
from django.http import HttpResponse, HttpResponseRedirect
from django.template import loader
from perfgraphs.models import *
from django import forms

class identificationForm(forms.Form):
    prenom = forms.CharField(max_length=200)
    nom = forms.CharField(max_length=200)

def afficher_graph_global(request, userid):
    user = Adherent.objects.get(id=userid)
    return render(request, "performances.html", {
        'graph': user.dessiner_graph_global().render(),
    })

def afficher_graph_course(request, userid, courseid):
    user = Adherent.objects.get(id=userid)
    performance = Performance.objects.get(id=courseid)
    return render(request, "performances.html", {
        'graph': performance.dessiner_graph_course(),
    })

def identification(request):
    def _invalid_or_new(request, form, message):
        return render(request, 'identification.html', {
            'form': form,
            'message': message,
        })

    if request.method == "POST":
        form = identificationForm(request.POST)

        if form.is_valid():
            try:
                adherent = Adherent.objects.get (nom=form.cleaned_data['nom'], prenom=form.cleaned_data['prenom'])
                return HttpResponseRedirect ('performances/%s/' % (adherent.id))
            except Adherent.DoesNotExist:
                return _invalid_or_new (request, identificationForm(), "Identifiants invalides. Recommencez svp.")
        
    else: return _invalid_or_new (request, identificationForm(), "Veuillez entrer vos identifiants")


