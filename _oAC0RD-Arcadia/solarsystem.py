# https://dev.to/sanjanamops8752/create-your-own-solar-system-using-python-5b6a?signin=true
import numpy as np
import math
import plotly.graph_objects as go

def spheres(size, clr, dist=0):
    theta = np.linespace(0,2*np.pi,100)