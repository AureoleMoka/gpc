from django.contrib import admin

from perfgraphs.models import *

class AdherentAdmin(admin.ModelAdmin):
    list_display = ('id', 'nom', 'prenom', 'adresse')


admin.site.register(Adherent, AdherentAdmin)
admin.site.register(Performance)
admin.site.register(Tour)
admin.site.register(Course)
