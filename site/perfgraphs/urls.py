from django.conf.urls import patterns, url
from perfgraphs import views

urlpatterns = patterns('',
        url(r'^$', views.identification, name='identification'),
        url(r'performances/(?P<userid>\d+)/$', views.afficher_graph_global, name='afficher_graph_global'),
)
